﻿using bugbank_selenium.Drivers;
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
        private IWebElement BtnSlideCreateAccountWithBalance => driver.FindElement(By.XPath("//label[@id='toggleAddBalance']"));
        private IWebElement BtnSignUp => driver.FindElement(By.XPath("//button[text()='Cadastrar']"));
        private IWebElement BtnBackToLogin => driver.FindElement(By.XPath("//div[@class='styles__ContainerBackButton-sc-7fhc7g-1 jokugX']"));
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

        public string GetModalRegisterMessage(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            var modalTextElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("modalText")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(modalTextElement, "foi criada com sucesso"));
            return modalTextElement.Text.Trim();
        }


        public string GetEmailFieldError()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var error = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card__register input[type='email'] + .input__warging")));
            return error.Text;
        }

        public string GetPasswordFieldError()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var error = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card__register input[name='password'] + .input__warging")));
            return error.Text;
        }

        public string GetPasswordConfirmationFieldError()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var error = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".card__register input[name='passwordConfirmation'] + .input__warging")));
            return error.Text;
        }
        public string GetModalPasswordMessage(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            var modalTextElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("modalText")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(modalTextElement, "As senhas não são iguais."));
            return modalTextElement.Text.Trim();
        }

        public void ReturnToLogin()
        {
            BtnBackToLogin.Click();
        }
    }
 
}
