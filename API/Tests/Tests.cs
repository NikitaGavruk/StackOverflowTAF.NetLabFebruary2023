using API.JsonModels;
using API.Units;
using Core.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace API.Tests
{

    [TestFixture]
    internal class Tests : BaseTest
    {

        private static XML_Reader reader = new XML_Reader(@"..\..\TestData\Endpoints.xml");
        API.APIUtils.API helper = new API.APIUtils.API();

        private static IEnumerable<TestCaseData> ErrorModels()
        {
            yield return new TestCaseData(new ClientError { error_id = 403, error_message = "access_token was not created with write_access scope", error_name = "access_denied" },
                "application/x-www-form-urlencoded", "key=jQbY46LJUbCnabOYlcGOBw((&access_token=Mc(9h6qsuI2HT3mI(TNTfA))&preview=true&filter=default&site=stackoverflow")
                .SetName("Is Access Token ReadOnly");
        }

        [Category("API Negative Tests")]
        [Test, TestCaseSource(nameof(ErrorModels))]
        public void AnswerUpvote(ClientError errorModel, string key, string value)
        {

            //Arrange
            string resourseEndpoint = string.Format(reader.GetTextFromNode("//Per-SiteMethods/answers/item/key"), reader.GetTextFromNode("//Per-SiteMethods/answers/item/value"));

            //Act
            RestRequest request = helper.CreatePostRequest(resourseEndpoint);
            request.AddParameter(key, value, ParameterType.RequestBody);
            RestResponse response = helper.GetResponse(request);

            //Assert
            ClientError model = helper.DeserializeToClass<ClientError>(response);
            Assert.That(errorModel.error_id, Is.EqualTo(model.error_id));
            Assert.That(errorModel.error_message, Is.EqualTo(model.error_message));
            Assert.That(errorModel.error_name, Is.EqualTo(model.error_name));

        }

        [Test, Description("test the badges api")]
        public void GetBadges()
        {

            //Arrange
            logger.Info("get the URI from XML file");
            string resourseEndpoint = reader.GetTextFromNode("//Per-SiteMethods/Badges/key");

            //Act
            logger.Info("make the get request with" +resourseEndpoint);
            RestRequest request = helper.CreateGetRequest(resourseEndpoint);
            logger.Info("add the parameter of site with the value of stackoverflow to Header");
            request.AddParameter("site", "stackoverflow", ParameterType.QueryString);
            logger.Info("execute the request to get response");
            RestResponse response = helper.GetResponse(request);

            //Assert
            logger.Info("convert response body to object of model");
            Root root = helper.DeserializeToClass<Root>(response);
            logger.Info("make ecpected object of model");
            Item item = new Item("tag_based", 41, "bronze", 2068, "https://stackoverflow.com/badges/2068/neural-network", "neural-network");
            logger.Info("checked if the response object is the same as expected object or not");
            Assert.That(root.items[0], Is.EqualTo(item));
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
