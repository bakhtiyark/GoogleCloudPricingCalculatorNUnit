namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class EstimateBlock(IWebDriver driver) : BaseComponent(driver, "#resultBlock")
{
    private readonly ComputeEngineEstimateComponent ComputerEngineEstimate = new(driver);
    private readonly SendEstimateEmailComponent SendEstimate = new(driver);

    public IWebElement EmailFormButton => driver.FindElement(By.XPath("//button[@id='Email Estimate']"));

    public void OpenEmailForm()
    {
        EmailFormButton.Click();
        var handles = driver.WindowHandles.ToList();
        driver.SwitchTo().Window(handles[0]);
    }

    public string GetData(string target, int index)
    {
        var itemElement = ComputerEngineEstimate.GetEstimateItem(target);
        var itemElementTextContent = itemElement.Text;
        var result = itemElementTextContent.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[index];
        return result;
    }

    public void SendEstimateMessage()
    {
        Actions actions = new Actions(driver);
        driver.SwitchTo().Frame(driver.FindElement(By.XPath("//devsite-iframe//iframe")));
        driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("#myFrame")));
        SendEstimate.Email.Click();
        actions.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Build();
        SendEstimate.SendEstimateButton.Click();
    }
}