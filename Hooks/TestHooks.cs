//Test setup/teardown

using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject_saucedemo.Drivers;

namespace ReqnrollProject_saucedemo.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _context;

        public TestHooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void Setup()
        {
            var driver = DriverFactory.InitDriver();
            _context["Driver"] = driver;
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [AfterScenario]
        public void TearDown()
        {
            var driver = (IWebDriver)_context["Driver"];
            driver.Quit();
        }
    }
}