using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReqnrollProject_Saucedemo.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver InitDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

           options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                      
            return new ChromeDriver(options);
        }
    }
}