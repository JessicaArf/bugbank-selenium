using bugbank_selenium.Drivers;
using bugbank_selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugbank_selenium.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver driver;

        public RegisterPage(IWebDriver driver)          {
            this.driver = driver;
        }

        private IWebElement BtnRegister => driver.FindElement(By.XPath("//button[text()='Registrar']"));
        private IWebElement InputEmail => driver.FindElement(By.CssSelector(".card__register input[type='email']"));
        private IWebElement InputName => driver.FindElement(By.CssSelector("input[type='name']"));
        private IWebElement InputPassword => driver.FindElement(By.CssSelector(".card__register input[name='password'"));
        private IWebElement InputPasswordConfirmation => driver.FindElement(By.CssSelector("input[name='passwordConfirmation'"));
        private IWebElement BtnSlideCreateAccountWithBalance => driver.FindElement(By.CssSelector(".styles__Container-sc-1pngcbh-0.kIwoPV #toggleAddBalance"));
        private IWebElement BtnSignUp => driver.FindElement(By.XPath("//button[text()='Cadastrar']"));
        private IWebElement BtnBackToLogin => driver.FindElement(By.Id("btnBackButton"));
        private string appUrl;


        public void AcessForm()
        {
            appUrl = ConfigurationHelper.GetAppUrl();
            driver.Navigate().GoToUrl(appUrl);
            BtnRegister.Click();
        }

        public void CreateAccount(string name, string email, string password, string passwordConfirmation)
        {
       
            InputEmail.SendKeys(email);
            InputName.SendKeys(name);
            InputPassword.SendKeys(password);
            InputPasswordConfirmation.SendKeys(passwordConfirmation);
            BtnSignUp.Click();
        }


      public void CreateAccountWithBalance(string name, string email, string password, string passwordConfirmation)
        {
            InputEmail.SendKeys(email);
            InputName.SendKeys(name);
            InputPassword.SendKeys(password);
            InputPasswordConfirmation.SendKeys(passwordConfirmation);
            BtnSlideCreateAccountWithBalance.Click();
            BtnSignUp.Click();
        }

        public string GetModalMessage(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            var modalTextElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("modalText")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(modalTextElement, "foi criada com sucesso"));
            return modalTextElement.Text.Trim();
        }


        public void ReturnToLogin()
        {
            BtnBackToLogin.Click();
        }
    }
 
}
