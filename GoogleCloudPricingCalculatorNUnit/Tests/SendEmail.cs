namespace GoogleCloudPricingCalculatorNUnit;
[TestFixture]
public class SendEmail : BaseTest
{

    [Test]
    [Description("Emailed prices should match")]
    public void CheckEmail()
    {
        try
        {
            string cost = Pages.Calculator.Estimate.GetData("estimatedCost", 4);
            Pages.Calculator.Estimate.OpenEmailForm();
            Pages.Calculator.Estimate.SendEstimateMessage();
            Pages.Email.ReceiveEstimate();
            string mailedPrice = Pages.Email.GetMailedPrice();
            Assert.That(mailedPrice, Is.EqualTo(cost));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }
}