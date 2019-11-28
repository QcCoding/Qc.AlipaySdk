using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Qc.AlipaySdk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Qc.AlipaySdk
{
    /// <summary>
    /// 支付宝服务
    /// </summary>
    public class AlipayOauthSdkService
    {
        private readonly HttpClient _httpClient;
        private readonly AlipayConfig _apiConfig;
        private readonly ILogger<AlipayOauthSdkService> _logger;

        public AlipayOauthSdkService(IHttpClientFactory _httpClientFactory
            , IAlipaySdkHook alipaySdkHook
            , ILogger<AlipayOauthSdkService> logger
            )
        {
            _logger = logger;
            _apiConfig = alipaySdkHook.GetConfig();
            if (_apiConfig == null)
                throw new Exception("Alipay not configured");
            _httpClient = _httpClientFactory.CreateClient("Alipay");
            if (_apiConfig.Timeout.HasValue)
                _httpClient.Timeout = TimeSpan.FromSeconds(_apiConfig.Timeout.Value);
        }
        /// <summary>
        /// 初始化参数，生成签名
        /// </summary>
        /// <param name="method"></param>
        /// <param name="defaultData"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetInitData(string method, Dictionary<string, string> defaultData = null)
        {
            var dicData = defaultData ?? new Dictionary<string, string>();
            dicData.Add("app_id", _apiConfig.AppId);
            dicData.Add("method", method);
            dicData.Add("charset", "utf-8");
            dicData.Add("sign_type", "RSA2");
            dicData.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dicData.Add("version", "1.0");
            dicData.Add("format", "JSON");
            dicData.Add("sign", Utils.AlipaySignature.RSASign(dicData, _apiConfig.AppPrivateKey, "utf-8", false, "RSA2"));
            return dicData;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public AlipayConfig GetConfig()
        {
            return _apiConfig;
        }
        /// <summary>
        /// 1.请求用户授权地址
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizeUrl(string callbackUrl, string state = "", string scope = "auth_user")
        {
            return $"{_apiConfig.ApiAuthorizeUrl}?app_id={_apiConfig.AppId}&scope={scope}&redirect_uri={System.Web.HttpUtility.UrlEncode(callbackUrl)}&state={state}";
        }

        /// <summary>
        /// 2.根据 Code 获取访问票据
        /// </summary>
        /// <returns></returns>
        public AlipayAccessTokenModel GetAccessTokenByCode(string code)
        {
            var dicData = GetInitData("alipay.system.oauth.token", new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code" },
                {"code", code}
            });
            var result = _httpClient.HttpPost<AlipayAccessTokenResultModel>(_apiConfig.ApiGateway, dicData, true);
            if (result == null || result.Response.IsError())
            {
                _logger.LogError("获取票据异常" + Utils.JsonHelper.Serialize(result));
            }
            return result?.Response;
        }
        /// <summary>
        /// 3.获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public AlipayUserInfoModel GetUserInfo(string code)
        {
            var accessResult = GetAccessTokenByCode(code);
            if (accessResult == null)
                return null;
            var dicData = GetInitData("alipay.user.info.share", new Dictionary<string, string>()
            {
                {"auth_token", accessResult.AccessToken }
            });
            var result = _httpClient.HttpPost<AlipayUserInfoResultModel>(_apiConfig.ApiGateway, dicData, true);
            if (result == null || result.Response.IsError())
            {
                _logger.LogError("获取用户信息异常" + Utils.JsonHelper.Serialize(result));
            }
            return result?.Response;
        }
    }
}
