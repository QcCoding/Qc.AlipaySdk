using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk
{
    public class DefaultAlipaySdkHook : IAlipaySdkHook
    {
        private readonly AlipayConfig _apiConfig;
        public DefaultAlipaySdkHook(IOptions<AlipayConfig> options)
        {
            _apiConfig = options?.Value;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public AlipayConfig GetConfig()
        {
            return _apiConfig;
        }
    }
}
