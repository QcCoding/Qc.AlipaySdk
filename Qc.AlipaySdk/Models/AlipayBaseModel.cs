using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk.Models
{
    public class AlipayBaseModel
    {
        /// <summary>
        /// 网关返回码
        /// </summary>
        /// <remarks>
        /// https://docs.open.alipay.com/common/105806
        /// </remarks>
        public string Code { get; set; }
        /// <summary>
        /// 网关返回码描述
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 业务返回码，参见具体的API接口文档
        /// </summary>
        public string Sub_code { get; set; }
        /// <summary>
        /// 业务返回码描述，参见具体的API接口文档
        /// </summary>
        public string Sub_msg { get; set; }
    }
}
