using OpenQA.Selenium;

namespace ReqnrollProject_Saucedemo.Pages;

public class CheckoutOverviewPage(IWebDriver driver)
{
    private readonly By _finishButton = By.Id("finish");
    private readonly By _itemTotal = By.CssSelector(".summary_subtotal_label");
    private readonly By _taxTotal = By.CssSelector(".summary_tax_label");
    private readonly By _totalLabel = By.CssSelector(".summary_total_label");

    public bool IsLoaded() => driver.Url.Contains("checkout-step-two");

    public string GetItemTotal() => driver.FindElement(_itemTotal).Text;
    public string GetTaxTotal() => driver.FindElement(_taxTotal).Text;
    public string GetTotal() => driver.FindElement(_totalLabel).Text;

    public void ClickFinish() =>
        driver.FindElement(_finishButton).Click();
}