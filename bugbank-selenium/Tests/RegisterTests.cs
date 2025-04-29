using NUnit.Framework;  
using bugbank_selenium.Drivers;
using bugbank_selenium.Pages;
using bugbank_selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace bugbank_selenium.Tests
{
    public class RegisterTests
    {

        private IWebDriver driver;
        private RegisterPage registerPage;
        


        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateChrome();
            registerPage = new RegisterPage(driver);
            registerPage.AcessForm();
        }

        [Test]
        public void ShouldRegisterSuccessfully()
        {
            var name = "jessica";
            var email = "jessica@email.com";
            var password = "senha12345";
            var passwordConfirmation = "senha12345";
            var expectedMessage = "foi criada com sucesso";

            registerPage.CreateAccount(name, email, password,passwordConfirmation);

            var message = registerPage.GetModalMessage(TimeSpan.FromSeconds(10));

            Assert.That(message, Does.Contain(expectedMessage),"A mensagem de sucesso esperada não foi encontrada no modal.");
        }

        [Test]
        public void ShouldRegisterAccountWithBalanceSuccessfully()
        {
            var name = "teste";
            var email = "teste@email.com";
            var password = "senha12345";
            var passwordConfirmation = "senha12345";
            var expectedMessage = "foi criada com sucesso";

            registerPage.CreateAccountWithBalance(name, email, password, passwordConfirmation);

            var message = registerPage.GetModalMessage(TimeSpan.FromSeconds(10));

            Assert.That(message, Does.Contain(expectedMessage), "A mensagem de sucesso esperada não foi encontrada no modal.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}
