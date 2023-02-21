using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        public static List<T> DeserializeRootObject(string body) => JsonConvert.DeserializeObject<List<T>>(body);
    }
}