//Test setup/teardown

using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject_Saucedemo.Drivers;
using System.Diagnostics;

namespace ReqnrollProject_Saucedemo.Hooks
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
            driver.Navigate().GoToUrl(Support.TestSettings.BaseUrl);
        }

        [AfterScenario]
        public void TearDown()
        {
            var driver = (IWebDriver)_context["Driver"];
            driver.Quit();
        }

        [AfterTestRun]
        public static void OpenReport()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var reportPath = Path.Combine(baseDir, "LivingDoc.html");

            if (File.Exists(reportPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = reportPath,
                    UseShellExecute = true
                });
            }
        }

    }
    }


