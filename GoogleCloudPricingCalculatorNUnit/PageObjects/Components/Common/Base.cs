namespace GoogleCloudPricingCalculatorNUnit.PageObjects.Components.Common
{
    public class BaseComponent
    {
        private readonly string rootSelector;
        private readonly IWebDriver driver;
        protected Helpers Helper { get; }

        public BaseComponent(IWebDriver driver, string rootSelector)
        {
            this.driver = driver;
            this.rootSelector = rootSelector;
            Helper = new Helpers(driver);
        }

        public IWebElement RootElement => driver.FindElement(By.CssSelector(rootSelector));

        public void Submit()
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Enter).Build().Perform();
        }
    }
}
