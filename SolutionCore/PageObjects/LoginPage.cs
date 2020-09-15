using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Threading;

namespace SolutionCore.PageObjects
{
    public class LoginPage
    {
        private WebDriverWait wait;

        private readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        private readonly string ConfigPassword = ConfigurationManager.AppSettings["Password"];
        IWebDriver driver;
        private IWebElement Username => driver.FindElement(By.Id("login-form-username")); //input[@id='login-form-username']
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));
        private IWebElement LoguinButton => driver.FindElement(By.Id("login"));
        private IWebElement LoguinButton2 => driver.FindElement(By.Id("login-form-submit"));
     //   private IWebElement labelLocator => wait.Until(driver => driver.FindElement(By.Id("gadget-10002-title")));


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage fillUsername()
        {
            Username.SendKeys(ConfigUsername);
            return this;
        }

        public LoginPage fillPassword()
        {
            Password.SendKeys(ConfigPassword);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoguinButton.Click();
            return this;
        }
        public LoginPage ClickLogin_2()
        {
            LoguinButton2.Click();
            return this;
        }
/*
        public bool isLoginSuccessful()
        {
            Thread.Sleep(3000);
            return labelLocator.Displayed;
        } */
    }
}
