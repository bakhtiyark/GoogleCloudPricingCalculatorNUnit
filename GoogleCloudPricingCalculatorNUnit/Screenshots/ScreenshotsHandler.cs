using System.Globalization;

namespace GoogleCloudPricingCalculatorNUnit.Screenshots;

public class ScreenshotsHandler(IWebDriver driver) : BasePage(driver)
{
    public ScreenshotsHandler TakeScreenshot()
    {
        string currentTime = DateTime.Now.ToString().Replace(":","-");
        string root = "c:";
        Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
        screenshot.SaveAsFile($@"{root}\GoogleCloudPricingCalculatorNUnit\GoogleCloudPricingCalculatorNUnit\Screenshots\ {currentTime}.png");
        return this;
    }
}