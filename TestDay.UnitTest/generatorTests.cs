using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDay.Front.Services;

namespace TestDay.UnitTest
{
    [TestClass]
    public class generatorTests
    {
        private Generator<short> __Generator;

        public generatorTests()
        {
            __Generator = new GeneratorShort();
        }

        [TestMethod]
        public void TestGenerateShort()
        {
            var value = __Generator.GetNext();
            Assert.IsTrue(value >= -32768 && value <= 32767);
        }
    }
}