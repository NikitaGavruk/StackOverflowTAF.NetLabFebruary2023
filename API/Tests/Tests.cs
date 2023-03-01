using API.JsonModels;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace API.Tests {
    
    [TestFixture]
    internal class Tests:BaseTest {
        
        API.APIUtils.API helper = new API.APIUtils.API();

        private static IEnumerable<TestCaseData> ErrorModels() {
            yield return new TestCaseData(new ClientError { error_id = 403, error_message = "access_token was not created with write_access scope", error_name = "access_denied" },
                "application/x-www-form-urlencoded", "key=jQbY46LJUbCnabOYlcGOBw((&access_token=Mc(9h6qsuI2HT3mI(TNTfA))&preview=true&filter=default&site=stackoverflow")
                .SetName("Is Access Token ReadOnly");
        }
        
        [Category("API Negative Tests")]
        [Test, TestCaseSource(nameof(ErrorModels))]
        public void AnswerUpvote(ClientError errorModel, string key, string value) {

            //Arrange
            string resourseEndpoint = string.Format(reader.GetTextFromNode("//Per-SiteMethods/answers/item/key"), reader.GetTextFromNode("//Per-SiteMethods/answers/item/value"));

            //Act
            logger.Info($"Create POST request taking the endpoint: {resourseEndpoint}");
            RestRequest request = helper.CreatePostRequest(resourseEndpoint);
            logger.Info($"Add Request Body");
            request.AddParameter(key, value, ParameterType.RequestBody);
            logger.Info($"Send The Request and get the Response");
            RestResponse response = helper.GetResponse(request);

            //Assert
            logger.Info($"Deserialize the response to type ({typeof(ClientError)})");
            ClientError model = helper.DeserializeToClass<ClientError>(response);
            logger.Info($"Assert That the sent properties are equal to the received ones");
            Assert.That(errorModel.error_id, Is.EqualTo(model.error_id));
            Assert.That(errorModel.error_message, Is.EqualTo(model.error_message));
            Assert.That(errorModel.error_name, Is.EqualTo(model.error_name));

        }

        [Category ("API Negative Tests")]
        [Test]
        public void GetWithWrongURI()
        {
            string wrongEndPoint = "2.3answers";
            logger.Info("Create Get request with wrong URI");
            RestRequest request = helper.CreateGetRequest(wrongEndPoint);
            logger.Info("Add query parameters");
            request.AddParameter("order", "desc");
            request.AddParameter("sort", "activity");
            request.AddParameter("site", "stackoverflow");
            logger.Info("Get response");
            RestResponse response = helper.GetResponse(request);
            logger.Info("Verify that status code is 400(Bad Request)");
            Assert.That(response.StatusCode == HttpStatusCode.BadRequest);
        }

    }

}
