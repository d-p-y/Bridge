﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Bridge.Test;

namespace Bridge.ClientTest.Text.RegularExpressions.Msdn
{
    [Category(Constants.MODULE_REGEX)]
    [TestFixture(TestNameFormat = "Regex.Escape - {0}")]
    public class RegexEscapeTests : RegexTestBase
    {
        #region Msdn

        [Test]
        public void EscapeTest()
        {
            var expected1 = new[] { "?", "?" };
            var actual1 = new List<string>();

            var expected2 = new[] { "[what kind?]", "[by whom?]" };
            var actual2 = new List<string>();


            string pattern = "[(.*?)]";
            string input = "The animal [what kind?] was visible [by whom?] from the window";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                actual1.Add(match.Value);
            }
            ValidateCollection(expected1, actual1.ToArray(), "MatchValues1");

            pattern = Regex.Escape("[") + "(.*?)]";
            MatchCollection matches2 = Regex.Matches(input, pattern);
            foreach (Match match in matches2)
            {
                actual2.Add(match.Value);
            }

            ValidateCollection(expected2, actual2.ToArray(), "MatchValues2");

        }

        [Test]
        public void UnescapeTest()
        {
            var pattern = "\n\r\t\f[](){}!123abc \\, *, +, ?, |, {, [, (,), ^, $,., #,  \a, \b, \t, and \v";
            var escaped = Regex.Escape(pattern);
            var unescaped = Regex.Unescape(escaped);

            Assert.AreEqual(pattern, unescaped);
        }

        #endregion

        [Test(ExpectedCount=0)]
        public void EscapeCharSetTest()
        {
            var escapable = "!\"#%&'()*,-./:;?@ABDGSWZ[\\]abdefnrstvwz{}";
            foreach (var ch in escapable)
            {
                try
                {
                    var rgx = new Regex(@"\" + ch);
                    rgx.Match("" + ch);
                }
                catch (Exception)
                {
                    Assert.False(true, "Char must be escapable: " + ch);
                }
            }
        }

        [Test]
        public void NonEscapeCharSetTest()
        {
            var escapable = "CEFHIJKLMNOPQRTUVXY_cghijklmopquxy";
            foreach (var ch in escapable)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var rgx = new Regex(@"\" + ch);
                    rgx.Match("" + ch);
                }, "Char must not be escapable: " + ch);
            }
        }
    }
}