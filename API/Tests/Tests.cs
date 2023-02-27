using API.JsonModels;
using API.Units;
using Core.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

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
            string resourseEndpoint = "/2.3/badges";

            //Act
            RestRequest request = helper.CreateGetRequest(resourseEndpoint);
            request.AddParameter("application/x-www-form-urlencoded", "?order=desc&sort=rank&site=stackoverflow",ParameterType.QueryString);
            RestResponse response = helper.GetResponse(request);

            //Assert
            Root root = helper.DeserializeToClass<Root>(response);

           // Console.WriteLine(root.items[0].badge_id);
           // Assert.That(root.items[1].badge_id, Is.EqualTo(2068));
        }


    }

}
