namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class CloudPage(IWebDriver driver) : BasePage(driver)
{
    private readonly HeaderComponent Header = new(driver);

    public void SearchText(string text)
    {
        Header.SearchIcon.Click();
        Header.SearchBox.SendKeys(text);
        Header.Submit();
    }

    public void GoTo()
    {
        driver.Navigate().GoToUrl(Constants.URL);
    }
}