namespace GoogleCloudPricingCalculatorNUnit;
[TestFixture]
public class SendEmail : BaseTest
{
    private readonly TestData _testData = new();

    [Test]
    [Description("Emailed prices should match")]
    public void CheckEmail()
    {
        string cost = Pages.Calculator.Estimate.GetData("estimatedCost", 4);
        Pages.Calculator.Estimate.OpenEmailForm();
        string originalWindow = driver.CurrentWindowHandle;

        // Email manipulation;
        driver.SwitchTo().NewWindow(WindowType.Tab);
        driver.Navigate().GoToUrl(_testData.Tempail);
        Pages.Email.CopyEmail();
        driver.SwitchTo().Window(originalWindow);
        Pages.Calculator.Estimate.SendEstimateMessage();

        driver.SwitchTo().Window(driver.WindowHandles.Last());
        Pages.Email.ReceiveEstimate();
        string mailedPrice = Pages.Email.GetMailedPrice();

        // Assertion
        Assert.That(mailedPrice, Is.EqualTo(cost));
    }
}