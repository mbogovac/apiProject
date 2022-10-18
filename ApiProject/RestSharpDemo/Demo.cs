using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace RestSharpDemo
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }

        public RestResponse GetUsers(string baseUrl)
        {
            var client = helper.SetUrl(baseUrl,"api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            //var users = HandleContent.GetContent<Users>(response);

            return response;
        }

        public RestResponse CreateNewUser(string baseUrl,dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            var jsonString = HandleContent.SerializeJsonString(payload);

            var request = helper.CreatePostRequest(jsonString);
            var response = helper.GetResponse(client, request);
            //var createUser = HandleContent.GetContent<CreateUserRes>(response);

            return response;
        }
    }
}
