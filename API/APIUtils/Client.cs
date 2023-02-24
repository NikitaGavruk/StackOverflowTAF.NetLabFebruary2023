using RestSharp;

namespace API.APIUtils
{
    internal class Client
    {
        private static string URL = "https://api.stackexchange.com/";
        private static Client _currentClient;
        private static RestClient _Client;

        private Client()
        {
            _Client = new RestClient(URL);
        }

        public static Client Instance => _currentClient ?? (_currentClient = new Client());

        public static RestClient GetClient => _Client;

        public static void QuitClient()
        {
            _currentClient = null;
            _Client = null;
        }
    }

}
