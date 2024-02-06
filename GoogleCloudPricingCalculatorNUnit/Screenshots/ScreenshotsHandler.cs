using System.Globalization;

namespace GoogleCloudPricingCalculatorNUnit.Screenshots;

public class ScreenshotsHandler(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver _driver = driver;

    public ScreenshotsHandler TakeScreenshot()
    {
        string currentTime = DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace(":","-");
        string root = "c:";
        Screenshot screenshot = ((_driver as ITakesScreenshot)!).GetScreenshot();
        screenshot.SaveAsFile($@"{root}\GoogleCloudPricingCalculatorNUnit\GoogleCloudPricingCalculatorNUnit\Screenshots\ {currentTime}.png");
        return this;
    }
}