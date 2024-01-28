namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Calculator;

public class SendEstimate(IWebDriver driver) : BaseComponent(driver, "form[name=\"emailForm\"]")
{
    // TODO: Perhaps i should find a better name
    public IWebElement SendEstimateButton => RootElement.FindElement(By.XPath("//button[contains(text(),\"Send Email\")]"));
    public IWebElement EmailInput => RootElement.FindElement(By.XPath("//input[@ng-model=\"emailQuote.user.email\"]"));
}