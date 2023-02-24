using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.APIUtils
{
    internal class Client
    {
        private static string URL = "https://stackoverflow.com";
        private static string Username = "";
        private static string Password = "";
        private static Client _currentClient;
        private static RestClient _Client;

        private Client()
        {
            _Client = new RestClient(URL);
        }

        public static Client Instance => _currentClient ?? (_currentClient = new Client());

        public static RestClient GetClient => _Client;

        public static RestClient GetClientAuth()
        {
            _Client.Authenticator = new HttpBasicAuthenticator(Username,Password);
            return _Client;
        }

        public static void QuitClient()
        {
            _currentClient = null;
            _Client = null;
        }
    }

}
