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
        private LoginPage loginPage;


        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateChrome();
            registerPage = new RegisterPage(driver);
            loginPage = new LoginPage(driver);  
            registerPage.AcessForm();
        }

        [Test]
        public void ShouldRegisterSuccessfully()
        {
            var name = "Jessica Souza";
            var email = "jessicasouza@email.com";
            var password = "senha12345";
            var passwordConfirmation = "senha12345";
            var expectedMessage = "foi criada com sucesso";

            registerPage.CreateAccount(name, email, password,passwordConfirmation);

            var message = registerPage.GetModalRegisterMessage(TimeSpan.FromSeconds(10));

            Assert.That(message, Does.Contain(expectedMessage),"A mensagem de sucesso esperada não foi encontrada no modal.");
        }

        [Test]
        public void ShouldRegisterAccountWithBalanceSuccessfully()
        {
            var name = "Lucas Santos";
            var email = "lucassantos@email.com";
            var password = "senha@1234";
            var passwordConfirmation = "senha@1234";
            var expectedMessage = "foi criada com sucesso";

            registerPage.CreateAccountWithBalance(name, email, password, passwordConfirmation);

            var message = registerPage.GetModalRegisterMessage(TimeSpan.FromSeconds(10));

            Assert.That(message, Does.Contain(expectedMessage), "A mensagem de sucesso esperada não foi encontrada no modal.");
        }

        [Test]
        public void ShouldShowErrorsWhenEmailAndPasswordAreEmpty()
        {
            var name = "";
            var email = "";
            var password = "";
            var passwordConfirmation = "";

            registerPage.CreateAccount(name, email, password, passwordConfirmation);

            var emailError = registerPage.GetEmailFieldError();
            var passwordError = registerPage.GetPasswordFieldError();
            var passwordConfirmationError = registerPage.GetPasswordConfirmationFieldError();

            Assert.That(emailError, Is.EqualTo("É campo obrigatório"), "Erro esperado no campo Nome não foi exibido.");
            Assert.That(passwordError, Is.EqualTo("É campo obrigatório"), "Erro esperado no campo Senha não foi exibido.");
            Assert.That(passwordConfirmationError, Is.EqualTo("É campo obrigatório"), "Erro esperado no campo Confirmação de Senha não foi exibido.");      
        }

        [Test]
        public void ShouldShowErrorWhenEmailIsInvalid()
        {
            var name = "Joana Silva";
            var email = "joanasilvaemail.com"; 
            var password = "senha12345";
            var passwordConfirmation = "senha12345";

            registerPage.CreateAccount(name, email, password, passwordConfirmation);

            var emailError = registerPage.GetEmailFieldError();

            Assert.That(emailError, Is.EqualTo("Formato inválido"), "Erro esperado no campo E-mail não foi exibido.");
        }

        [Test]
        public void ShouldShowErrorWhenPasswordsAreDifferent()
        {
            var name = "Amanda Santos";
            var email = "amandasantos@email.com";
            var password = "senha@1234";
            var passwordConfirmation = "senha@65432";
            var expectedMessage = "As senhas não são iguais.";

            registerPage.CreateAccount(name, email, password, passwordConfirmation);

            var message = registerPage.GetModalPasswordMessage(TimeSpan.FromSeconds(10));

            Assert.That(message, Does.Contain(expectedMessage), "A mensagem de erro esperada não foi encontrada no modal.");
        }

        [Test]
        public void ShouldReturnToLoginPageFromRegisterPage()
        {
            registerPage.AcessForm();
            registerPage.ReturnToLogin();

            var isLoginVisible = loginPage.IsLoginButtonVisible(TimeSpan.FromSeconds(10));


            Assert.That(isLoginVisible, Is.True, "Não retornou para a tela de login.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}
