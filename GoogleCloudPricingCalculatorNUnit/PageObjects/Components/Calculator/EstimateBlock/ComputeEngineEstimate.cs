namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class ComputeEngineEstimateComponent(IWebDriver driver) : BaseComponent(driver, "md-content #compute")
{
    public IWebElement GetEstimateItem(string name)
    {
        var selectors = new Dictionary<string, string>
        {
            { "location", "//div[contains(text(),'Region:')]" },
            { "cud", "//div[contains(text(),'Commitment term:')]" },
            { "class", "//div[contains(text(),'Provisioning model:')]" },
            { "instance", "//div[contains(text(),'Instance type:')]" },
            { "os", "//div[contains(text(),'Operating System / Software:')]" },
            { "gpu", "//div[contains(text(),'Operating System / GPU dies:')]" },
            { "ssd", "//div[contains(text(),'Local SSD:')]" },
            { "estimatedCost", "//div//b[contains(text(),'Estimated Component Cost:')]" },
        };

        return RootElement.FindElement(By.XPath(selectors[name]));
    }
}