using OpenQA.Selenium;

namespace ReqnrollProject_Saucedemo.Pages;

public class CartPage(IWebDriver driver)
{
    private readonly By _checkoutButton = By.Id("checkout");
    private readonly By _cartItems = By.CssSelector(".cart_item");
    private readonly By _removeButton = By.CssSelector(".cart_button");

    public bool IsLoaded() => driver.Url.Contains("cart");

    public int GetCartItemCount() =>
        driver.FindElements(_cartItems).Count;

    public void ClickCheckout() =>
        driver.FindElement(_checkoutButton).Click();
}