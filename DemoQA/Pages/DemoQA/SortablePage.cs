using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/sortable"; } }

        public IWebElement TabList => Wait.Until(d => d.FindElement(By.XPath("//a[@id='demo-tab-list']")));

        public IWebElement ListElement(string listElement)
        {
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@id='demo-tabpane-list']//div[text()='{listElement}']")));
        }

        public IWebElement TabGrid => Wait.Until(d => d.FindElement(By.XPath("//a[@id='demo-tab-grid']")));

        public IWebElement GridElement(string gridElement)
        {
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='create-grid']/div[text()='{gridElement}']")));
        }
    }
}
