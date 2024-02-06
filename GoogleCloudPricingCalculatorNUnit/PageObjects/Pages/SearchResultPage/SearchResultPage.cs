namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class SearchResultPage(IWebDriver driver) : BasePage(driver)
{
    public IWebElement LocatorForLegacy => Helper.LocateElement(Locators.Xpath,
        "//*[@track-metadata-eventdetail=\"cloud.google.com/products/calculator-legacy\"]");

    public void ClickSearchResult()
    {
        LocatorForLegacy.Click();
    }
}