namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class SendEstimateEmailComponent(IWebDriver driver): BaseComponent(driver, "form[name='emailForm'")
{
    private readonly IWebDriver _driver = driver;
    public IWebElement SendEstimateButton => _driver.FindElement(By.XPath("//button[contains(text(),\"Send Email\")]"));
    public IWebElement Email => _driver.FindElement(By.XPath("//input[@ng-model='emailQuote.user.email']"));
}