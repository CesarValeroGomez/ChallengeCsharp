using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolutionCore.PageObjects
{
    public class CreateIssuePage
    {
        IWebDriver driver;
        private WebDriverWait wait;

        IWebElement CreateButton => wait.Until(driver => driver.FindElement(By.Id("create_link")));
        IWebElement IssueInEpic => driver.FindElement(By.Id("gh-create-issue-in-epic-lnk"));
        IWebElement IssueType => wait.Until(driver => driver.FindElement(By.Id("issuetype-field")));
        IWebElement epicName => wait.Until(driver => driver.FindElement(By.Id("customfield_10104")));

        IWebElement SummaryIssue => wait.Until(driver => driver.FindElement(By.Id("summary")));

      //  IWebElement descriptionIssue => driver.FindElement(By.CssSelector("#tinymce"));
    //    IWebElement descriptionIssue => wait.Until(driver => driver.FindElement(By.XPath("//body[contains(@class,'mce-content-body')]")));
        IWebElement descriptionIssue => wait.Until(driver => driver.FindElement(By.XPath("//body[@id='tinymce']//p")));
        IWebElement SendFormButton => driver.FindElement(By.Id("create-issue-submit"));
        IWebElement IssueCreated => wait.Until(driver => driver.FindElement(By.XPath("//tr[@class='issuerow']")));
        IWebElement EpicCreated => wait.Until(driver => driver.FindElement(By.ClassName("aui-message-success")));
        IWebElement WorkFlowLocator => wait.Until(driver => driver.FindElement(By.Id("opsbar-transitions_more")));
        IWebElement InProgressLocator => driver.FindElement(By.XPath("//aui-item-link[@id='action_id_31']/a/span"));
        IWebElement InDoneLocator => driver.FindElement(By.XPath("//aui-item-link[@id='action_id_41']/a/span"));
        IWebElement WorkFlowStatus => wait.Until(driver => driver.FindElement(By.CssSelector(".jira-issue-status-lozenge")));
     
        public CreateIssuePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public CreateIssuePage ClickCreateButton()
        {
            CreateButton.Click();
            return this;
        }

        public CreateIssuePage ClickOnNewEpicRelated()
        {
            IssueInEpic.Click();
            return this;
        }
        public CreateIssuePage SelectIssueType(String issue)
        {
            IssueType.Click();
            IssueType.SendKeys(issue);
            return this;
        }
        public CreateIssuePage FillEpicName(String issue)
        {
            epicName.Click();
            epicName.SendKeys(issue);
            return this;
        }

        public CreateIssuePage FillSummaryField(String summarytxt)
        {
            SummaryIssue.Click();
            SummaryIssue.SendKeys(summarytxt);
            return this;
        }
        public CreateIssuePage FillDescriptionField(String descriptiontxt)
        {
            descriptionIssue.Click();
            descriptionIssue.SendKeys(descriptiontxt);
            return this;
        }
        public CreateIssuePage SenndIssueForm()
        {
            SendFormButton.Click();
            return this;
        }

        public bool isEpicCreated()
        {
            return EpicCreated.Displayed;
        }

        public bool isIssueCreatedInEpic()
        {
            return IssueCreated.Displayed;
        }

        public CreateIssuePage ClickOnWorkflow()
        {
            WorkFlowLocator.Click();
            return this;
        }
        public CreateIssuePage ClickInProgress()
        {
            InProgressLocator.Click();
            return this;
        }
        public CreateIssuePage ClickInDone()
        {
            InDoneLocator.Click();
            return this;
        }
        public string validateWorkFlowStatus()
        {
            Thread.Sleep(3000);
            return WorkFlowStatus.Text;
        }
    }
}
