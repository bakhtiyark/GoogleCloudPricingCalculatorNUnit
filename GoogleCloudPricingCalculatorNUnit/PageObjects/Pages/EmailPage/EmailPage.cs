namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class EmailPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver _driver = driver;

    public IWebElement CopyEmailButton => _driver.FindElement(By.CssSelector(".kopyala-link"));
    public IWebElement Email => _driver.FindElement(By.CssSelector("#epostalar li:nth-child(2) a"));
    public IWebElement Price => _driver.FindElement(By.CssSelector("tr:last-child td:last-child h3"));
    public IWebElement ClosePopUp => _driver.FindElement(By.Id("dismiss-button"));

    public void CopyEmail()
    {
        CopyEmailButton.Click();
    }

    public void ReceiveEstimate()
    {
        
        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        _driver.SwitchTo().Frame("aswift_4");
        ClosePopUp.Click();
        _driver.SwitchTo().ParentFrame();
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.EMAIL_TIMEOUT));
        wait.Until(d => Email.Displayed);
        
        Email.Click();
    }

    public string GetMailedPrice()
    {
        WebDriverWait waitIframe = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        waitIframe.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("iframe"));

        IWebElement mailedCost = Price;

        string mailedCostTextContent = mailedCost.Text;
        return mailedCostTextContent.Split(" ")[1];
    }
}