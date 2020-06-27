using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class SortablePage : BasePage
    {
        public SortablePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/sortable"; } }

        public WebElement TabList => Driver.FindExistingElement(By.XPath("//a[@id='demo-tab-list']"));

        public WebElement ListElement(string listElement)
        {
                return Driver.FindClickableElement(By.XPath($"//div[@id='demo-tabpane-list']//div[text()='{listElement}']"));
        }

        public WebElement TabGrid => Driver.FindExistingElement(By.XPath("//a[@id='demo-tab-grid']"));

        public WebElement GridElement(string gridElement)
        {
                return Driver.FindClickableElement(By.XPath($"//div[@class='create-grid']/div[text()='{gridElement}']"));
        }
    }
}
