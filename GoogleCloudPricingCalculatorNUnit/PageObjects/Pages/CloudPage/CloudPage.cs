namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class CloudPage(IWebDriver driver) : BasePage(driver)
{
    private readonly HeaderComponent _header = new(driver);
    private readonly IWebDriver _driver = driver;

    public void SearchText(string text)
    {
        _header.SearchIcon.Click();
        _header.SearchBox.SendKeys(text);
        _header.Submit();
    }

    public void GoTo()
    {
        _driver.Navigate().GoToUrl(Constants.URL);
    }
}