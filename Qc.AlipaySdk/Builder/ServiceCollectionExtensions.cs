using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加支付宝开放平台SDK，注入默认实现的DefaultAlipaySdkHook
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddAlipaySdk(this IServiceCollection services, Action<AlipayConfig> optionsAction)
        {
            services.AddAlipaySdk<DefaultAlipaySdkHook>(optionsAction);

            return services;
        }
        /// <summary>
        /// 添加支付宝开放平台SDK，可注入自定义的IAlipaySdkHook
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddAlipaySdk<T>(this IServiceCollection services, Action<AlipayConfig> optionsAction = null) where T : class, IAlipaySdkHook
        {
            if (optionsAction != null)
            {
                services.Configure(optionsAction);
            }
            services.AddScoped<IAlipaySdkHook, T>();
            services.AddScoped<AlipayOauthSdkService, AlipayOauthSdkService>();
            services.AddHttpClient();
            return services;
        }
    }
}
