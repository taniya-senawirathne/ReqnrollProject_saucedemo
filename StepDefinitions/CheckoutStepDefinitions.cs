using NUnit.Framework;
using OpenQA.Selenium;
using ReqnrollProject_Saucedemo.Pages;
using ReqnrollProject_Saucedemo.Support;

namespace ReqnrollProject_Saucedemo.StepDefinitions
{
    [Binding]
    public sealed class CheckoutStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutInfoPage _checkoutInfoPage;
        private readonly CheckoutOverviewPage _checkoutOverviewPage;
        private readonly CheckoutCompletePage _checkoutCompletePage;

        public CheckoutStepDefinitions(ScenarioContext context)
        {
            _driver = (IWebDriver)context["Driver"];
            _loginPage = new(_driver);
            _inventoryPage = new(_driver);
            _cartPage = new(_driver);
            _checkoutInfoPage = new(_driver);
            _checkoutOverviewPage = new(_driver);
            _checkoutCompletePage = new(_driver);
        }

        [Given("I am logged in as a standard user")]
        public void GivenIAmLoggedInAsAStandardUser()
        {
            //_loginPage.NavigateTo();
            _loginPage.Login(TestSettings.Username, TestSettings.Password);
            Assert.That(_inventoryPage.IsLoaded(), Is.True, "Expected to be on the inventory page after login.");
        }

        [Given("I add {string} to the cart")]
        [When("I add {string} to the cart")]
        public void WhenIAddItemToCart(string itemName)
        {
            _inventoryPage.AddItemToCartByName(itemName);
        }

        [Given("I navigate to the cart")]
        [When("I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            _inventoryPage.GoToCart();
            Assert.That(_cartPage.IsLoaded(), Is.True);
        }

        [When("I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            _cartPage.ClickCheckout();
            Assert.That(_checkoutInfoPage.IsLoaded(), Is.True);
        }

        [When("I fill in my details with first name {string} last name {string} and postal code {string}")]
        public void WhenIFillInMyDetails(string firstName, string lastName, string postalCode)
        {
            _checkoutInfoPage.FillInformation(firstName, lastName, postalCode);
            _checkoutInfoPage.ClickContinue();
            Assert.That(_checkoutOverviewPage.IsLoaded(), Is.True);
        }

        [When("I submit the checkout form without filling in any details")]
        public void WhenISubmitWithoutDetails()
        {
            _checkoutInfoPage.ClickContinue();
        }

        [When("I confirm the order")]
        public void WhenIConfirmTheOrder()
        {
            _checkoutOverviewPage.ClickFinish();
        }

        [Then("I should see the order confirmation message")]
        public void ThenIShouldSeeTheOrderConfirmationMessage()
        {
            Assert.That(_checkoutCompletePage.IsLoaded(), Is.True);
            Assert.That(_checkoutCompletePage.IsOrderConfirmed(), Is.True);
            Assert.That(_checkoutCompletePage.GetSuccessHeader(), Is.EqualTo("Thank you for your order!"));
        }

        [Then("the cart badge should show {string}")]
        public void ThenTheCartBadgeShouldShow(string expectedCount)
        {
            Assert.That(_inventoryPage.GetCartBadgeCount(), Is.EqualTo(expectedCount));
        }

        [Then("I should see the item total on the overview page")]
        public void ThenIShouldSeeItemTotal()
        {
            Assert.That(_checkoutOverviewPage.GetItemTotal(), Does.Contain("Item total:"));
        }

        [Then("I should see the tax amount on the overview page")]
        public void ThenIShouldSeeTaxAmount()
        {
            Assert.That(_checkoutOverviewPage.GetTaxTotal(), Does.Contain("Tax:"));
        }

        [Then("I should see an error message on the checkout information page")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            var error = _checkoutInfoPage.GetErrorMessage();
            Assert.That(error, Is.Not.Empty);
        }
    }
}
