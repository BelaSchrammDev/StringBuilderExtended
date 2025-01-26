using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace StringBuilderTest.Tests
{
    [TestClass]
    public class StringBuilderMSTest
    {
        private readonly StringBuilderExtended sbx;

        public StringBuilderMSTest()
        {
            sbx = new StringBuilderExtended(100);

        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        [DataRow("Hello World", "World", 6)]
        [DataRow("Hello World", "WORLD", -1)]
        [DataRow(" ereu(sms) \n", "(sms", 5)]
        public void TestIndexOf(string input, string search, int expected)
        {
            sbx.SetText(input);
            Assert.AreEqual(expected, sbx.IndexOf(search));
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(sbx.IsEmpty());
            sbx.Append("Hello");
            Assert.IsFalse(sbx.IsEmpty());
        }

        [TestMethod]
        public void TestTrim()
        {
            sbx.SetText(" ereu(sms) \n");
            sbx.Trim();
            Assert.AreEqual("ereu(sms)", sbx.ToString());
        }

        [TestMethod]
        [DataRow("Hello World", 6, 5, "World")]
        [DataRow("Hello World test", 6, 5, "World")]
        public void TestSubString(string initial, int startIndex, int length, string expected)
        {
            StringBuilder sb = new StringBuilder(100);
            sbx.SetText(initial);
            sbx.Substring(sb, startIndex, length);
            Assert.AreEqual(expected, sb.ToString());
        }

        [TestMethod]
        public void TestToLower()
        {
            sbx.SetText("Hello World#");
            sbx.ToLower();
            Assert.AreEqual("hello world#", sbx.ToString());
        }

        [TestMethod]
        [DataRow("Hello World", "World", true)]
        [DataRow("Hello World", "WORLD", false)]
        public void TestContains(string input, string search, bool expected)
        {
            sbx.SetText(input);
            Assert.AreEqual(expected, sbx.Contains(search));
        }
    }
}
