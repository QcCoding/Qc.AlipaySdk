using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk
{

    public class AlipayConfig : AlipayBaseConfig
    {
        /// <summary>
        /// 授权地址
        /// </summary>
        public string ApiAuthorizeUrl { get; set; } = "https://openauth.alipay.com/oauth2/publicAppAuthorize.htm";

        /// <summary>
        /// 接口网关
        /// </summary>
        public string ApiGateway { get; set; } = "https://openapi.alipay.com/gateway.do";
        /// <summary>
        /// 请求超时时间
        /// </summary>
        public int? Timeout { get; set; } = 30;
    }
}
