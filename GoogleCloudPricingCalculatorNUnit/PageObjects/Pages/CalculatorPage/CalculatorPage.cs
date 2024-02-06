namespace GoogleCloudPricingCalculatorNUnit.PageObjects;
public class CalculatorPage(IWebDriver driver) : BasePage(driver)
{
    private readonly TabsBlock _tabs = new(driver);
    public readonly EstimateBlock Estimate = new(driver);
    private readonly IWebDriver _driver = driver;

    public void FillForm(TestData testData)
    {
        SwitchToTargetFrame();

        FillQuantity(testData);
        SelectDropdownEl("os", testData);
        SelectDropdownEl("series", testData);
        SelectDropdownEl("instance", testData);
        FillCheckbox("addGPUs");
        SelectDropdownEl("gpuType", testData);
        SelectDropdownEl("gpuCount", testData);
        SelectDropdownEl("ssd", testData);
        SelectDropdownEl("location", testData);
        SelectDropdownEl("cud", testData);
    }

    public void SwitchToTargetFrame()
    {
        _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//devsite-iframe//iframe")));
        _driver.SwitchTo().Frame(_driver.FindElement(By.CssSelector("#myFrame")));
    }

    public void SubmitForm()
    {
        _tabs.AddToEstimateButton.Click();
    }

    private void FillQuantity(TestData data)
    {
        IWebElement formElement = _tabs.ComputeEngineForm.GetFormItem("quantity");

        formElement.SendKeys(data.Access("quantity"));
    }


    private void FillCheckbox(string fieldName)
    {
        IWebElement formElement = _tabs.ComputeEngineForm.GetFormItem(fieldName);
        formElement.Click();
    }

    private void SelectDropdownEl(string fieldName, TestData data)
    {
        IWebElement formElement = _tabs.ComputeEngineForm.GetFormItem(fieldName);
        formElement.Click();
        IWebElement targetValue = _tabs.DropdownValue(data.Access(fieldName));
        targetValue.Click();
    }
}