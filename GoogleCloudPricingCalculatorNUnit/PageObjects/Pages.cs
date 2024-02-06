using OpenQA.Selenium.Support.Extensions;

namespace GoogleCloudPricingCalculatorNUnit.PageObjects;
internal class Pages : BaseTest
{
    public static CloudPage Cloud = null!;
    public static CalculatorPage Calculator = null!;
    private static SearchResultPage _searchResult = null!;
    public static EmailPage Email = null!;

    public static void Init(IWebDriver driver)
    {
        Cloud = new CloudPage(driver);
        Calculator = new CalculatorPage(driver);
        _searchResult = new SearchResultPage(driver);
        Email = new EmailPage(driver);
    }

    public static void OpenCalculatorPage()
    {
        Cloud.SearchText(TestData.SearchQuery);
        _searchResult.ClickSearchResult();
    }
}