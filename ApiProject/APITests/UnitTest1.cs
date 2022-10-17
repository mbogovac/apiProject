using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using System;

namespace APITests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var api = new Demo();
            var response = api.GetUsers();
            Assert.AreEqual(2, response.page);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                             }";

            var api = new Demo();
            var response = api.CreateNewUser(payload);

            Assert.AreEqual("morpheus", response.name);
        }
    }
}
