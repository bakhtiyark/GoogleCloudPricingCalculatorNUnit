namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class TabsBlock(IWebDriver driver) : BaseComponent(driver, "md-tabs")
{
    private readonly IWebDriver _driver = driver;
    public ComputeEngineForm ComputeEngineForm { get; } = new(driver);

    public IWebElement AddToEstimateButton => RootElement.FindElement(By.XPath("//button[@ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']"));

    public IWebElement DropdownValue(string text)
    {
        return _driver.FindElement(By.XPath($"//body/div/md-select-menu//md-option//div[normalize-space(text())='{text}']"));
    }
}