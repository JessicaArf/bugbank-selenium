using bugbank_selenium.Drivers;
using bugbank_selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugbank_selenium.Tests
{
    public class LoginTests
    {


        private IWebDriver driver;
        private LoginPage loginPage;
        private RegisterPage registerPage;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateChrome();
            registerPage = new RegisterPage(driver);
            loginPage = new LoginPage(driver);
            loginPage.AccessLoginForm();
        }

        [Test]
        public void ShouldLoginSuccessfully()
        {
            registerPage.AcessForm();   
            var name = "Joana Silva";
            var email = "joanasilva@email.com";
            var password = "senha12345";
            var passwordConfirmation = "senha12345";

            registerPage.CreateAccount(name, email, password, passwordConfirmation);
            

            var urlExpected = Utils.ConfigurationHelper.GetAppUrl() + "home";

            loginPage.LoginWithValidCredentials(email, password);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == urlExpected);

            var urlNow = driver.Url;
           
            Assert.That(urlNow, Is.EqualTo(urlExpected));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
