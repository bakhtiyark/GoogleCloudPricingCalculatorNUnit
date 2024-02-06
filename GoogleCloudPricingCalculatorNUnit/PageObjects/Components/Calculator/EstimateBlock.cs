namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class EstimateBlock(IWebDriver driver) : BaseComponent(driver, "#resultBlock")
{
    private readonly TestData _testData = new();
    private readonly ComputeEngineEstimateComponent ComputerEngineEstimate = new(driver);
    private readonly SendEstimateEmailComponent SendEstimate = new(driver);
    private readonly IWebDriver _driver = driver;

    public IWebElement EmailFormButton => _driver.FindElement(By.XPath("//button[@id='Email Estimate']"));

    public void OpenEmailForm()
    {
        EmailFormButton.Click();
        var handles = _driver.WindowHandles.ToList();
        _driver.SwitchTo().Window(handles[0]);
        
        string originalWindow = _driver.CurrentWindowHandle;
        
        _driver.SwitchTo().NewWindow(WindowType.Tab);
        _driver.Navigate().GoToUrl(_testData.Tempail);
        Pages.Email.CopyEmail();
        _driver.SwitchTo().Window(originalWindow);
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
        _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//devsite-iframe//iframe")));
        _driver.SwitchTo().Frame(_driver.FindElement(By.CssSelector("#myFrame")));
        SendEstimate.Email.Click();
        SendEstimate.Email.SendKeys(Keys.Control + "V");
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.EMAIL_TIMEOUT));
        wait.Until(ExpectedConditions.ElementToBeClickable(SendEstimate.SendEstimateButton));

        SendEstimate.SendEstimateButton.Click();
    }
}