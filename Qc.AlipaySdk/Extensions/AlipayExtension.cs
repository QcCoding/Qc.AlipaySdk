using Qc.AlipaySdk.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Qc.AlipaySdk
{
    public static class AlipayApiExtension
    {
        public static bool IsError(this AlipayBaseModel input)
        {
            if (input == null)
                return true;
            if (string.IsNullOrEmpty(input.Code))
                return false;
            return input.Code != "10000";
        }
    }
}
