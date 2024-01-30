using GoogleCloudPricingCalculatorNUnit.Screenshots;

public class BaseTest
{
    readonly TestData _testData = new ();
    public ScreenshotsHandler ScreenshotsHandler;
    
    [OneTimeSetUp]
    public void TestSetup()
    {
        DriverHandler.Browser("chrome");
        ScreenshotsHandler = new(DriverHandler.Driver);
        Pages.Init(DriverHandler.Driver);
        Pages.Cloud.GoTo();
        Pages.OpenCalculatorPage();
        Pages.Calculator.FillForm(_testData);
        Pages.Calculator.SubmitForm();
    }
   
    [OneTimeTearDown]
    public void TestEnding()
    {
        DriverHandler.Driver.Quit();
    }
}