using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReqnrollProject_Saucedemo.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver InitDriver()
        {
            var options = new ChromeOptions();

            // Run headless when the CI environment variable is set.
            // This is required on GitHub Actions (no display available).
            if (Environment.GetEnvironmentVariable("HEADLESS") == "true")
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--window-size=1920,1080");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            return new ChromeDriver(options);
        }
    }
}