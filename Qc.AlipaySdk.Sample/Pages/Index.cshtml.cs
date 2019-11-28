using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Qc.AlipaySdk.Models;

namespace Qc.AlipaySdk.Sample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AlipayOauthSdkService _service;
        public IndexModel(AlipayOauthSdkService service)
        {
            _service = service;
        }
        public string AppId { get; set; }
        public IActionResult OnGet()
        {
            AppId = _service.GetConfig()?.AppId;
            var actType = Request.Query["state"].ToString();
            var code = Request.Query["auth_code"];
            if (actType.StartsWith("callback"))
            {
                //回调处理
                if (actType.EndsWith("base"))
                {
                    var accessResult = _service.GetAccessTokenByCode(code);
                    return new JsonResult(accessResult);
                }
                var user = _service.GetUserInfo(code);
                return new JsonResult(user);
            }
            return Page();
        }
        /// <summary>
        /// 授权登录
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostOauthLogin()
        {
            if (IsAlipayBroswer())
            {
                return OnPostRedirectOauthLogin();
            }
            var callbackUrl = _service.GetAuthorizeUrl(GetRawUrl(), "callback");
            return Redirect(callbackUrl);
        }
        /// <summary>
        /// 跳转授权
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostRedirectOauthLogin()
        {
            if (!IsAlipayBroswer())
            {
                return Content("请使用支付宝打开");
            }
            return Content(@"<script src='https://gw.alipayobjects.com/as/g/h5-lib/alipayjsapi/3.1.1/alipayjsapi.inc.min.js'></script>
<script>
        ap.getAuthCode({
            appId: '" + _service.GetConfig().AppId + @"',
            scopes: ['auth_user'],
            showErrorTip:false,
        }, function (res) {
            if (res.authCode) {
                location.href = '/?state=callback&auth_code=' + res.authCode;
            } else {
                ap.alert(res.errorMessage)
            }
        })
</script>", "text/html;charset=utf-8");
        }
        /// <summary>
        /// 是否支付宝浏览器
        /// </summary>
        /// <returns></returns>
        bool IsAlipayBroswer()
        {
            //Console.WriteLine(Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.UserAgent].ToString());
            return Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.UserAgent].ToString().ToLower().Contains("alipay");
        }
        /// <summary>
        /// 当前URL
        /// </summary>
        /// <returns></returns>
        string GetRawUrl()
        {
            var callbackUrl = new StringBuilder()
                .Append(Request.Scheme)
                .Append("://")
                .Append(Request.Headers["X-FORWARDED-HOST"])
                .Append(Request.PathBase)
                .Append(Request.Path)
                .Append(Request.QueryString)
                .ToString();
            return callbackUrl.ToString();
        }
    }
}
