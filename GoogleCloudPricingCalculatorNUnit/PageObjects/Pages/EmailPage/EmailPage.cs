namespace GoogleCloudPricingCalculatorNUnit.PageObjects;

public class EmailPage(IWebDriver driver) : BasePage(driver)
{
    
    public IWebElement CopyEmailButton => driver.FindElement(By.CssSelector(".kopyala-link"));
    public IWebElement Email => driver.FindElement(By.CssSelector("#epostalar li:nth-child(2) a"));
    public IWebElement Price => driver.FindElement(By.CssSelector("tr:last-child td:last-child h3"));

    public void CopyEmail()
    {
        CopyEmailButton.Click();
    }

    public void ReceiveEstimate()
    {
        
        driver.SwitchTo().Window(driver.WindowHandles.Last());
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.EMAIL_TIMEOUT));
        wait.Until(d => Email.Displayed);
        
        Email.Click();
    }

    public string GetMailedPrice()
    {
        WebDriverWait waitIframe = new WebDriverWait(driver, TimeSpan.FromSeconds(690));
        waitIframe.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("iframe"));

        IWebElement mailedCost = Price;

        string mailedCostTextContent = mailedCost.Text;
        return mailedCostTextContent.Split(" ")[1];
    }
}