namespace GoogleCloudPricingCalculatorNUnit;

[TestFixture]
public class PriceCheck : BaseTest
{
    private readonly TestData _testData = new();

    [Test]
    [Description("Conformance check - should have the same location")]
    public void ShouldHaveSameLocation()
    {
        try
        {
            string location = Pages.Calculator.Estimate.GetData("location", 1);
            Assert.That(location, Is.EqualTo(_testData.Access("location").Split(" ")[0]));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }

    [Test]
    [Description("Conformance check - should have the same commitment term")]
    public void ShouldHaveSameCommitmentTerm()
    {
        try
        {
            string cud = Pages.Calculator.Estimate.GetData("cud", 2);
            Assert.That(cud, Is.EqualTo(_testData.Access("cud").Split(' ')[0]));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }

    [Test]
    [Description("Conformance check - should have the same VM class")]
    public void ShouldHaveSameVmClass()
    {
        try
        {
            string vm = Pages.Calculator.Estimate.GetData("class", 2);
            Assert.That(vm, Is.EqualTo(_testData.Access("class")));
        }

        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }

    [Test]
    [Description("Conformance check - should have the same instance type")]
    public void ShouldHaveSameInstanceType()
    {
        try
        {
            string instance = Pages.Calculator.Estimate.GetData("instance", 2);
            Assert.That(instance.Contains(_testData.Access("instance").Split(" ")[0]));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }

    [Test]
    [Description("Conformance check - should have the same SSD")]
    public void ShouldHaveSameSsd()
    {
        try
        {
            string ssd = Pages.Calculator.Estimate.GetData("ssd", 2);
            Assert.That(ssd, Is.EqualTo(_testData.Access("ssd").Split(' ')[0]));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }

    [Test]
    [Description("Conformance check - should have the same price per month as if filled manually")]
    public void ShouldHaveSamePricePerMonth()
    {
        try
        {
            string cost = Pages.Calculator.Estimate.GetData("estimatedCost", 4);
            Assert.That(cost, Is.EqualTo(_testData.Access("estimatedCost")));
        }
        catch (Exception ex)
        {
            ScreenshotsHandler.TakeScreenshot();
            throw new Exception(nameof(ex));
        }
    }
}