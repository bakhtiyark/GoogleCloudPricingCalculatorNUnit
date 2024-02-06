namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Common;

public class HeaderComponent : BaseComponent
{
    private readonly Helpers _helper;
    public HeaderComponent(IWebDriver driver) : base(driver, ".devsite-header--inner")
    {
        _helper = new Helpers(driver);
    }

    public IWebElement SearchIcon => _helper.LocateElement(Locators.ClassName, "YSM5S");
    public IWebElement SearchBox => _helper.LocateElement(Locators.Xpath, "//*[@placeholder=\"Search\"]");
}