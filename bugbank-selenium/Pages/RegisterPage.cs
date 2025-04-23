using bugbank_selenium.Drivers;
using OpenQA.Selenium;
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

        private IWebElement BtnRegister => driver.FindElement(By.CssSelector("button[type='button']"));
        private IWebElement InputEmail => driver.FindElement(By.CssSelector("input[type='email']"));
        private IWebElement InputName => driver.FindElement(By.CssSelector("input[type='name']"));
        private IWebElement InputPassword => driver.FindElement(By.CssSelector("input[name='password'"));
        private IWebElement InputPasswordConfirmation => driver.FindElement(By.CssSelector("input[name='passwordConfirmation'"));
        private IWebElement BtnSlideCreateAccountWithBalance => driver.FindElement(By.Id("toggleAddBalance"));
        private IWebElement BtnSignUp => driver.FindElement(By.CssSelector("button[type='button']"));
        private IWebElement BtnBackToLogin => driver.FindElement(By.Id("btnBackButton"));


        public void AcessForm()
        {
            driver.Navigate().GoToUrl("https://bugbank.netlify.app/");
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


        public void ReturnToLogin()
        {
            BtnBackToLogin.Click();
        }
    }
 
}
