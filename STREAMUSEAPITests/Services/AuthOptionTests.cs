using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace STREAMUSEAPI.Services.Tests
{
    [TestClass()]
    public class AuthOptionTests
    {
        [TestMethod()]
        public void HashPasswordTest_ReturnsTrue()
        {
            string password = "password";

            string excepted = AuthOption.HashPassword(password);
            string actual = AuthOption.HashPassword(password);

            Assert.IsTrue(excepted == actual);
        }
    }
}