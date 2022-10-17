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

        public Users GetUsers()
        {
            var client = helper.SetUrl("api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            var users = helper.GetContent<Users>(response);

            return users;
        }

        public CreateUserRes CreateNewUser(string payload)
        {
            var client = helper.SetUrl("api/users");
            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(client, request);
            var createUser = helper.GetContent<CreateUserRes>(response);

            return createUser;
        }
    }
}
