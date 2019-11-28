using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk
{
    public class AlipayBaseConfig
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// SecretKey
        /// </summary>
        public string AppPrivateKey { get; set; }
    }
}
