using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugbank_selenium.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            return new ChromeDriver(options);
        }
    }
}
