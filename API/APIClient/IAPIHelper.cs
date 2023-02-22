using RestSharp;

namespace API.APIClient {

    internal interface IAPIHelper {

        RestResponse GET_Request(string resource, string id);
        RestResponse POST_Request<T>(T payload, string resource, string resourceString = "") where T : class, new();

    }

}
