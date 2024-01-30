using OpenQA.Selenium.Support.Extensions;

namespace GoogleCloudPricingCalculatorNUnit.PageObjects;
internal class Pages : BaseTest
{
    public static CloudPage Cloud;
    public static CalculatorPage Calculator;
    public static SearchResultPage SearchResult;
    public static EmailPage Email;

    public static void Init(IWebDriver driver)
    {
        Cloud = new CloudPage(driver);
        Calculator = new CalculatorPage(driver);
        SearchResult = new SearchResultPage(driver);
        Email = new EmailPage(driver);
    }

    public static void OpenCalculatorPage()
    {
        Cloud.SearchText(TestData.SearchQuery);
        SearchResult.ClickSearchResult();
    }
}