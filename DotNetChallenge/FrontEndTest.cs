using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using SolutionCore.PageObjects;
using System.Threading;
using OpenQA.Selenium;
using SolutionCore.WrapperFactory;

namespace DotNetChallenge
{
    [TestFixture]
    public class FrontEndTest
    {
          ChromeDriver _driver;
      //  IWebDriver _driver;
        private WebDriverWait _wait;
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

     //   [SetUp]
        public void SetUp(String endPoint)
        {
            _driver = new ChromeDriver
            {
                Url = BaseUrl+endPoint
            }; 
          //  BrowserFactory.InitBrowser("Chrome");
          //  BrowserFactory.LoadApplication(ConfigurationManager.AppSettings[BaseUrl + endPoint]);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
        }

           [Test]
            public void JiraAllowsToTheUserLoginIn()
            {
                SetUp("");
                var loginPage = new LoginPage(_driver);
                loginPage
                    .fillUsername()
                    .fillPassword()
                    .ClickLogin();
                Thread.Sleep(3000);
                var jiraLogo = _driver.FindElementById("gadget-10002-title");
                Assert.IsTrue(jiraLogo.Displayed);
          //  Assert.IsTrue(loginPage.isLoginSuccessful());
            Console.WriteLine("Successfully Login ");
            }  
        
        [Test]
        public void CreateNewTicket()
        {
            SetUp("");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            var createissuePage = new CreateIssuePage(_driver, _wait);
            createissuePage.ClickCreateButton()
                .SelectIssueType("Epic")
                .FillEpicName("Important Epic")
                .FillSummaryField("Summary Issue for New Epic ")
                .SenndIssueForm();
    
            Assert.IsTrue(createissuePage.isEpicCreated());
            Console.WriteLine("New Epic Created ");
            Thread.Sleep(5000);
        }

           
        [Test]
        public void CreateStoryInEpic()
        {
            SetUp("/browse/JIR-1");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var createissuePage = new CreateIssuePage(_driver, _wait);
            createissuePage.ClickOnNewEpicRelated()
                .SelectIssueType("Story")
                .FillSummaryField("Summary Issue for Story")
                 .SenndIssueForm();
                Assert.IsTrue(createissuePage.isIssueCreatedInEpic());
                Console.WriteLine("Story created in the Epic ");
                Thread.Sleep(5000);
        }

        [Test]
        public void CreateBugInEpic()
        {
            SetUp("/browse/JIR-1");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var createissuePage = new CreateIssuePage(_driver, _wait);
            createissuePage.ClickOnNewEpicRelated()
                .SelectIssueType("Bug")
                .FillSummaryField("Summary Issue for Defect")
                 .SenndIssueForm();
            Assert.IsTrue(createissuePage.isIssueCreatedInEpic());
            Console.WriteLine("Bug created in the Epic ");
            Thread.Sleep(5000);
        }
       
        [Test]
        public void MoveTicketToInProgress()
        {
            SetUp("/browse/JIR-3");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var createissuePage = new CreateIssuePage(_driver, _wait);
            createissuePage.ClickOnWorkflow()
                .ClickInProgress();
            Assert.AreEqual("IN PROGRESS", createissuePage.validateWorkFlowStatus());
            Console.WriteLine("Ticket was Moved to In Progress ");
            Thread.Sleep(5000);
        }  
        
        [Test]
        public void MoveTicketToDone()
        {
            SetUp("/browse/JIR-4");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var createissuePage = new CreateIssuePage(_driver, _wait);
            createissuePage.ClickOnWorkflow()
                .ClickInDone();
            Assert.AreEqual("DONE", createissuePage.validateWorkFlowStatus());
            Console.WriteLine("Ticket was Moved to Done ");
            Thread.Sleep(3000);
        }

        [Test]
        public void AssingBugToMe()
        {
            SetUp("/browse/JIR-44");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var bugdashboard = new Bugdashboard(_driver, _wait);
            bugdashboard.
                AssigToMeBug();
            Assert.IsTrue(bugdashboard.isBugAssignedToMe());
            Console.WriteLine("Bug Assigned to me ");
            Thread.Sleep(5000);
        }
        [Test]
        public void CloneBug()
        {
            SetUp("/browse/JIR-44");
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin_2();
            var bugdashboard = new Bugdashboard(_driver, _wait);
            bugdashboard.
                CloneBugs();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
