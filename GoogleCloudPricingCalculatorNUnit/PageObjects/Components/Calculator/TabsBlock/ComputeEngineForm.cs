namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class ComputeEngineForm : BaseComponent
{
    public ComputeEngineForm(IWebDriver driver) : base(driver,"form[name=ComputeEngineForm]")
    {
    }
    public IWebElement GetFormItem(string name)
    {
        var selectors = new Dictionary<string, string>
        {
            { "quantity", "//form//input[@id='input_100']" },
            { "label", "//form//input[@id='input_97']" },
            { "os", "//*[@id=\"select_113\"]" },
            { "class", "//form//*[@id='select_113']" },
            { "family", "//form//*[@id='select_119']" },
            { "series", "//*[@placeholder=\"Series\"]" },
            { "instance", "//*[@placeholder=\"Instance type\"]" },
            { "threads", "//form//*[@id='select_224']" },
            { "bootDiskType", "//form//*[@id='select_125']" },
            { "bootDiskSize", "//form//*[@id='input_127']" },
            { "addGPUs", "//md-checkbox[@aria-label='Add GPUs']" },
            { "gpuType", "//md-select[@placeholder='GPU type']" },
            { "gpuCount", "//md-select[@placeholder='Number of GPUs']" },
            { "ssd", "//*[@placeholder=\"Local SSD\"]" },
            { "location", "//*[@placeholder=\"Datacenter location\"]" },
            { "cud", "//*[@placeholder=\"Committed usage\"]" },
        };

        return RootElement.FindElement(By.XPath(selectors[name]));
    }
}