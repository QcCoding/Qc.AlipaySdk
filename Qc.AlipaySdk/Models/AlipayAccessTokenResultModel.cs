using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk.Models
{
    public class AlipayAccessTokenResultModel
    {
        [Newtonsoft.Json.JsonProperty("alipay_system_oauth_token_response")]
        public AlipayAccessTokenModel Response { get; set; }
        public string Sign { get; set; }
    }
    public class AlipayUserInfoResultModel
    {
        [Newtonsoft.Json.JsonProperty("alipay_user_info_share_response")]
        public AlipayUserInfoModel Response { get; set; }
        public string Sign { get; set; }
    }
}
