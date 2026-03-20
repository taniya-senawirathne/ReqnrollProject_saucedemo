using OpenQA.Selenium;

namespace ReqnrollProject_Saucedemo.Pages;

public class CheckoutInfoPage(IWebDriver driver)
{
    private readonly By _firstNameField = By.Id("first-name");
    private readonly By _lastNameField = By.Id("last-name");
    private readonly By _postalCodeField = By.Id("postal-code");
    private readonly By _continueButton = By.Id("continue");
    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    public bool IsLoaded() => driver.Url.Contains("checkout-step-one");

    public void FillInformation(string firstName, string lastName, string postalCode)
    {
        driver.FindElement(_firstNameField).SendKeys(firstName);
        driver.FindElement(_lastNameField).SendKeys(lastName);
        driver.FindElement(_postalCodeField).SendKeys(postalCode);
    }

    public void ClickContinue() =>
        driver.FindElement(_continueButton).Click();

    public string GetErrorMessage() =>
        driver.FindElement(_errorMessage).Text;
}