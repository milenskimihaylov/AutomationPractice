using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/selectable"; } }

        public IWebElement TabList => Wait.Until(d => d.FindElement(By.XPath("//a[@id='demo-tab-list']")));

        public IWebElement ElementFromTheList(int elementNumber)
        {
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//ul[@id='verticalListContainer']/li[{elementNumber}]")));
        }

        public IWebElement TabGrid => Wait.Until(d => d.FindElement(By.XPath("//a[@id='demo-tab-grid']")));

        public IWebElement ElementFromTheGrid(string elementName)
        {            
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//li[text()='{elementName}']")));
        }
    }
}
