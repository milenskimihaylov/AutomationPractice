using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class ResizablePage : BasePage
    {
        public ResizablePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/resizable"; } }

        public WebElement ResizableBox => Driver.FindClickableElement(By.Id("resizable"));

        public WebElement ResizeButtonResizableBox => Driver.FindClickableElement(By.CssSelector("#resizable > span"));

        public WebElement ResizableBoxWithRestriction => Driver.FindClickableElement(By.Id("resizableBoxWithRestriction"));

        public WebElement ResizeButtonResizableBoxWithRestriction => Driver.FindClickableElement(By.CssSelector("#resizableBoxWithRestriction > span"));
    }
}
