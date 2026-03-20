using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReqnrollProject_saucedemo.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver InitDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}