using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.AlipaySdk
{
    public interface IAlipaySdkHook
    {
        AlipayConfig GetConfig();
    }
}
