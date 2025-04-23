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

        private IWebElement BtnOpenRegisterForm => driver.FindElement(By.CssSelector("button_child"));
        
        public void acess()
        {
            driver.Navigate().GoToUrl("https://bugbank.netlify.app/#");
            BtnOpenRegisterForm.Click();
        }

      
    }
 
}
