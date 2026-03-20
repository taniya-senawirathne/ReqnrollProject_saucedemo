using OpenQA.Selenium;

namespace ReqnrollProject_Saucedemo.Pages;

public class InventoryPage(IWebDriver driver)
{
    private readonly By _inventoryItems = By.CssSelector(".inventory_item");
    private readonly By _cartBadge = By.CssSelector(".shopping_cart_badge");
    private readonly By _cartLink = By.CssSelector(".shopping_cart_link");

    public bool IsLoaded() =>
        driver.Url.Contains("inventory");

    public void AddFirstItemToCart()
    {
        var addButton = driver.FindElement(By.CssSelector(".btn_inventory"));
        addButton.Click();
    }

    public void AddItemToCartByName(string itemName)
    {
        var items = driver.FindElements(_inventoryItems);
        foreach (var item in items)
        {
            if (item.FindElement(By.CssSelector(".inventory_item_name")).Text == itemName)
            {
                item.FindElement(By.CssSelector(".btn_inventory")).Click();
                return;
            }
        }
    }

    public string GetCartBadgeCount() =>
        driver.FindElement(_cartBadge).Text;

    public void GoToCart() =>
        driver.FindElement(_cartLink).Click();
}