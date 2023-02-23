using RestSharp;

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
