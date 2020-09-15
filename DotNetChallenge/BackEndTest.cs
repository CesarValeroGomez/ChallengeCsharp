using NUnit.Framework;
using RestSharp;
using System;
using RestSharp.Authenticators;
using System.Configuration;
using SolutionCore.ApiWorkFlow;
using SolutionCore.Builders;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace DotNetChallenge
{
    [TestFixture]
    [AllureNUnit]
    [AllureLink("https://github.com/CesarValeroGomez/prueba")]
    public class BackEndTest
    {
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        private readonly string ConfigPassword = ConfigurationManager.AppSettings["Password"];
        RestClient restClient;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
        }

        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CreateNewTicket()
        {
            var createIssue = new CreateIssueBuilder().
                WithIssueType("Epic").
                WithIssueName("EpicTest").
                Build();
            var issue = new Issue(restClient);
            var objectResponse = issue.CreateIssue(createIssue);
            
            AllureLifecycle.Instance.WrapInStep(
            () => {
                Console.WriteLine(objectResponse.key);
                Assert.IsNotNull(objectResponse.key);
            },
            "Validate Creation of Epic");
        }  
        
        [Test]
        public void AssingANewStoryToEpic()
        {
            var createIssue = new CreateIssueBuilder().
                WithIssueType("Epic").
                WithIssueName("EpicTest").
                Build();
            var issue = new Issue(restClient);
            var objectResponse = issue.CreateIssue(createIssue);
            var statusCodeResponse = issue.UpdateIssue("JIR-2", objectResponse.key);
            Assert.AreEqual("NoContent", statusCodeResponse); 
            Console.WriteLine(objectResponse.key); 
            Assert.AreEqual("NoContent", statusCodeResponse);
        }

        
        [Test]
        public void AddCommentInEpic()
        {
            var addComment = new AddCommentBuilder().
                WithComment("The Issue is very Tricky 4").
               Build();
            var issue = new Issue(restClient);
            var objectResponse = issue.AddingComment(addComment, "JIR-4");
            Assert.AreEqual("Created", objectResponse, "The Comment was added to the Epic");
            Console.WriteLine("The Comment was  "+objectResponse);
        }
        
        [Test]
        public void SetPriorityToTicket()
        {
            var issue = new Issue(restClient);

            var objectResponse = issue.SetPriority("High", "JIR-5");
            Console.WriteLine("The Status Code was  " + objectResponse);
            Assert.AreEqual(204, objectResponse);
        }

        [Test]
        public void AmendSummaryAndDescription()
        {
            var issue = new Issue(restClient);
            
            var objectResponse = issue.UpdateSummaryAndDescrip("Amende in Summary", "Amend in Description", "JIR-5");
            Console.WriteLine("The Status Code was  " + objectResponse);
            Assert.AreEqual(204, objectResponse);
        }
    }
}
