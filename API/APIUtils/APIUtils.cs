using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace API.RestUtils
{
    internal class APIUtils
    {
        public static HttpWebResponse MakeRequest(HttpWebRequest request)
        {
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public static string GetBody(HttpWebResponse response)
        {
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responceBody = reader.ReadToEnd();
            return responceBody;
        }
        public static List<T> DeserializeRootObject<T>(string body) => JsonConvert.DeserializeObject<List<T>>(body);
    }
}