using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;
using System;
using System.Net;

namespace APITests
{
    [TestClass]
    public class SmokeTests
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode StatusCode;
        private const string BASE_URL = "https://reqres.in/";

        [TestMethod]
        public void TestMethod1()
        {
            var api = new Demo();
            var response = api.GetUsers(BASE_URL);
            //Assert.AreEqual(2, response.page);
        }

        //[DeploymentItem("TestData\\CreateUser.csv"),
        //    DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV","CreateUser.csv","CreateUser#csv", DataAccessMethod.Sequential)]

        [DeploymentItem("TestData")]

        [TestMethod]
        public void CreateUserTest()
        {
            //string payload = @"{
            //                    ""name"": ""morpheus"",
            //                    ""job"": ""leader""
            //                 }";

            //var user = new CreateUserRequest
            //{
            //   name = TestContext.DataRow["Name"].ToString(),
            //   job = TestContext.DataRow["Job"].ToString()
            //};

            var payload = HandleContent.ParseJson<CreateUserRequest>("CreateUser.json");

            var api = new Demo();
            var response = api.CreateNewUser(BASE_URL, payload);
            StatusCode = response.StatusCode;
            var code = (int)StatusCode;
            Assert.AreEqual(201, code);

            var userContent = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(payload.name, userContent.name);
        }
    }
}
