namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class SearchResultPage(IWebDriver driver) : BasePage(driver)
{
    private readonly HeaderComponent Header = new(driver);
    public IWebElement LocatorForLegacy => Helper.LocateElement(Locators.Xpath,
        "//a[@data-ctorig=\"https://cloud.google.com/products/calculator-legacy\"]");

    public void ClickSearchResult()
    {
        LocatorForLegacy.Click();
    }
}