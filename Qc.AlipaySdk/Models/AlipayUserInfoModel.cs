using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Qc.AlipaySdk.Models
{
    public class AlipayUserInfoModel : AlipayBaseModel
    {
        /// <summary>
        /// 支付宝用户的userId
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// 用户头像地址
        /// </summary>
        [JsonProperty("Avatar")]
        public string Avatar { get; set; }
        /// <summary>
        /// 	省份名称
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 用户昵称	
        /// </summary>
        [JsonProperty("nick_name")]
        public string NickName { get; set; }
        /// <summary>
        /// 是否是学生
        /// </summary>
        [JsonProperty("is_student_certified")]
        public string IsStudentCertified { get; set; }
        /// <summary>
        /// 用户类型 1代表公司账户 2代表个人账户
        /// </summary>
        [JsonProperty("user_type")]
        public string UserType { get; set; }
        /// <summary>
        ///用户状态（Q/T/B/W）。
        // Q 代表快速注册用户
        // T 代表正常用户
        // B 代表被冻结账户
        // W 代表已注册，未激活的账户
        /// </summary>
        [JsonProperty("user_status")]
        public string UserStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_certified")]
        public string IsCertified { get; set; }
        /// <summary>
        /// 性别（F：女性；M：男性）
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
    }
}
