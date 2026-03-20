using OpenQA.Selenium;

namespace ReqnrollProject_Saucedemo.Pages;

public class CheckoutCompletePage(IWebDriver driver)
{
    private readonly By _successHeader = By.CssSelector(".complete-header");
    private readonly By _successText = By.CssSelector(".complete-text");
    private readonly By _backHomeButton = By.Id("back-to-products");

    public bool IsLoaded() => driver.Url.Contains("checkout-complete");

    public string GetSuccessHeader() =>
        driver.FindElement(_successHeader).Text;

    public bool IsOrderConfirmed() =>
        driver.FindElement(_successHeader).Displayed;
}