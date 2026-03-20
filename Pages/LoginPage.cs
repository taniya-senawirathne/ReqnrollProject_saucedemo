using OpenQA.Selenium;


namespace ReqnrollProject_Saucedemo.Pages;

public class LoginPage(IWebDriver driver)
{
    private readonly By _usernameField = By.Id("user-name");
    private readonly By _passwordField = By.Id("password");
    private readonly By _loginButton = By.Id("login-button");
    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    public void NavigateTo() => driver.Navigate().GoToUrl(Support.TestSettings.BaseUrl);

    public void EnterUsername(string username) =>
        driver.FindElement(_usernameField).SendKeys(username);

    public void EnterPassword(string password) =>
        driver.FindElement(_passwordField).SendKeys(password);

    public void ClickLogin() =>
        driver.FindElement(_loginButton).Click();

    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
    }

    public string GetErrorMessage() =>
        driver.FindElement(_errorMessage).Text;
}