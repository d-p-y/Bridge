using System;
using Bridge.Test;

namespace Bridge.ClientTest.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1083 - {0}")]
    public class Bridge1083
    {
        [Test]
        public static void TestExternalEnum()
        {
            // simulate declaration of external enum 
            Script.Write("Bridge.ClientTest.BridgeIssues.Bridge1083.Foo = {};");
            Script.Write("Bridge.ClientTest.BridgeIssues.Bridge1083.Foo.OK = 'OK';");
            Script.Write("Bridge.ClientTest.BridgeIssues.Bridge1083.Foo.FAIL = 'FAIL';");

            var status = Foo.Ok;

            Assert.AreEqual("OK", status.ToString());
        }

        [External]
        [Enum(Emit.Name)]
        public enum Foo
        {
            [Name("OK")]
            Ok,

            [Name("FAIL")]
            Fail
        }
    }
}