using API.Schema;
using OpenQA.Selenium.DevTools.V107.Network;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
﻿using RestSharp;

namespace API.APIUtils
{
    internal class API
    {
        private Client _client = Client.Instance;

        public static RestResponse GetRequest(string Uri)
        {
            var request = new RestRequest(Uri, Method.Get);
            return Client.GetClient.Execute(request);
        }

        public static RestResponse PostRequest(string Uri, string body)
        {
            var request = new RestRequest(Uri, Method.Post);
            request.AddBody(body);
            return Client.GetClient.Execute(request);
        }
    }
}
