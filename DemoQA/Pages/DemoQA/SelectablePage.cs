using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class SelectablePage : BasePage
    {
        public SelectablePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/selectable"; } }

        public WebElement TabList => Driver.FindExistingElement(By.XPath("//a[@id='demo-tab-list']"));

        public WebElement ElementFromTheList(int elementNumber)
        {
                return Driver.FindClickableElement(By.XPath($"//ul[@id='verticalListContainer']/li[{elementNumber}]"));
        }

        public WebElement TabGrid => Driver.FindExistingElement(By.XPath("//a[@id='demo-tab-grid']"));

        public WebElement ElementFromTheGrid(string elementName)
        {            
                return Driver.FindClickableElement(By.XPath($"//li[text()='{elementName}']"));
        }
    }
}
