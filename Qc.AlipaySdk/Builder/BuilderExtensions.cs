using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Qc.AlipaySdk
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseAlipaySdk(this IApplicationBuilder app, Func<AlipayConfig> configHandler)
        {
            return app;
        }
    }
}
