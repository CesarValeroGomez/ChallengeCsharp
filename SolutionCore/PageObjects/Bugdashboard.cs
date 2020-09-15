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
    public class Bugdashboard
    {
        IWebDriver driver;
        private WebDriverWait wait;


        IWebElement AssignToMe => wait.Until(driver => driver.FindElement(By.Id("assign-to-me")));
        IWebElement ToadMessage => wait.Until(driver => driver.FindElement(By.ClassName("aui-message closeable aui-message-success aui-will-close")));
        IWebElement Clone => wait.Until(driver => driver.FindElement(By.ClassName("trigger-label")));
        IWebElement CloneSummary => wait.Until(driver => driver.FindElement(By.ClassName("summary")));
        IWebElement CloneSubmit => wait.Until(driver => driver.FindElement(By.Id("clone-issue-submit")));
        IWebElement BugDone => wait.Until(driver => driver.FindElement(By.Id("action_id_31")));
        IWebElement UpdatedBug => wait.Until(driver => driver.FindElement(By.Id("aui - message closeable aui - message - success aui - will - close")));
        public Bugdashboard(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public Bugdashboard AssigToMeBug()
        {
            AssignToMe.Click();
            return this;
        }

        public bool isBugAssignedToMe()
        {
            return ToadMessage.Displayed;
        }

        public Bugdashboard CloneBugs()
        {
            Clone.Click();
            Thread.Sleep(3000);
            CloneSubmit.Click();
            return this;
        }

        public bool isBugClone()
        {
            return ToadMessage.Displayed;
        }

        public Bugdashboard BugsDone()
        {
            BugDone.Click();
            return this;
        }
        public bool isBugUpdated()
        {
            return UpdatedBug.Displayed;
        }
    }
}
