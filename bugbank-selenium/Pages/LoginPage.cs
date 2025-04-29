using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugbank_selenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement BtnLogin => driver.FindElement(By.XPath("//button[text()='Acessar']"));

        public bool IsLoginButtonVisible(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Acessar']"))).Displayed;
        }
    }
}
