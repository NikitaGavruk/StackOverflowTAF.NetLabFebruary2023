using API.Exceptions;
using Core.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;

namespace API.APIClient {

    internal class ApiClient {

        private RestClient client;
        public RestRequest request { get; private set; }
        private const string baseUrl = "https://api.stackexchange.com/";
        private static XML_Reader TestDatareader = new XML_Reader(@"..\..\..\UI\Tests\TestData.xml");
        private static XML_Reader Endpointsreader = new XML_Reader(@"..\..\TestData\Endpoints.xml");

        public ApiClient(string endpoint = "") {
            SetUrl(endpoint);
        }

        public RestClient SetUrl(string endpoint) {
            string url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public void SetAuthenticator() {
            string email = TestDatareader.GetTextFromNode("//Email");
            string password = TestDatareader.GetTextFromNode("//Password");
            client.Authenticator = new HttpBasicAuthenticator(email, password);
        }

        private RestRequest AddingParameters(ParameterType type,params (string key, string value)[] header) {

            foreach ((string key, string value) in header) {
                request.AddParameter(key, value, type);
            }

            return request;
        }

        public RestRequest CreateHeadRequest(string resource) {
            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            request = new RestRequest(resource, Method.Head);
            AddingParameters(ParameterType.HttpHeader, ("Accept", "application/json"));
            return request;
        }

        public RestRequest CreateGetRequest(string resource, 
            params (string key, string value)[] headers) {

            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            request = new RestRequest(resource, Method.Get);
            if(headers!=null)
                AddingParameters(ParameterType.HttpHeader, headers);
            return request;
        }

        public RestRequest CreatePostRequest(string resource, 
            params (string key, string value)[] headers) {

            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            request = new RestRequest(resource, Method.Post);
            if(headers!=null)
                AddingParameters(ParameterType.HttpHeader, headers);

            return request;
        }

        public RestRequest CreatePostRequest<TModel>(string resource, TModel model,
            params (string key, string value)[] headers) where TModel : class {

            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            request = new RestRequest(resource, Method.Post);
            if (model != null)
                request.AddJsonBody<TModel>(model);
            if (headers != null)
                AddingParameters(ParameterType.HttpHeader, headers);

            return request;
        }

        public RestResponse GetResponse(RestRequest request) {
            if (client != null && request != null)
                return client.Execute(request);
            throw new NullReferenceException("The client or the request are not initialized");
        }

        public T DeserializeToClass<T>(RestResponse response) where T: class, new()  {
            if (response != null)
                return JsonConvert.DeserializeObject<T>(response.Content);
            throw new NullReferenceException("The response is null");
        }

        public string SerializeToString<T>(T model) where T : class, new() {
            return JsonConvert.SerializeObject(model);
        }

    }

}
