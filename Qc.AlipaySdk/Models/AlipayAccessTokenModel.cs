using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk.Models
{
    public class AlipayAccessTokenModel: AlipayBaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// 访问令牌
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 过期时间(秒)
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// 刷新有效期
        /// </summary>
        [JsonProperty("re_expires_in")]
        public int ReExpiresIn { get; set; }
    }
}
