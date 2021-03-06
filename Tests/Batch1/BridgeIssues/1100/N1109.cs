using System;
using System.Collections.Generic;
using Bridge.Test;

namespace Bridge.ClientTest.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1109 - {0}")]
    public class Bridge1109
    {
        [Test]
        public static void TestTemplateOnProperty()
        {
            Script.Write("var gamedata1 = 1;");
            Assert.AreEqual(1, gamedata);
        }

        public static extern dynamic gamedata
        {
            [Template("gamedata1")]
            get;
        }
    }
}