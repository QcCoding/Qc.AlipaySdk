using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Qc.AlipaySdk.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = HttpClientExtension.AppendUrlQuery("/asdf", new System.Collections.Generic.Dictionary<string, string>() { { "key", "233" } });
        }

    }
}
