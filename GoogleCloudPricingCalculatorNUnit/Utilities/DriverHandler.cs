namespace GoogleCloudPricingCalculatorNUnit.Utilities;

public class DriverHandler
{
    public static IWebDriver Driver { get; private set; }

    public DriverHandler(IWebDriver driver)
    {
        Driver = driver;
        
    }

    public static void Browser(string browser)
    {
        switch (browser)
        {   
            case "chrome":
                new DriverManager().SetUpDriver(new ChromeConfig());
                Driver = new ChromeDriver(); break;
            case "firefox":
                new DriverManager().SetUpDriver(new FirefoxConfig());
                Driver = new FirefoxDriver(); break;
            case "edge":
                new DriverManager().SetUpDriver(new EdgeConfig());
                Driver = new EdgeDriver(); break;
            case "safari":
                Driver = new SafariDriver(); break;
        }
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.WAIT_TIMEOUT);
    }
}