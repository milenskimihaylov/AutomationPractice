using OpenQA.Selenium;
using System.Threading;

namespace DemoQA.Pages.DemoQA
{
    public class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/resizable"; } }

        public IWebElement ResizableBox => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("resizable")));

        public IWebElement ResizeButtonResizableBox => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#resizable > span")));

        public IWebElement ResizableBoxWithRestriction => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("resizableBoxWithRestriction")));

        public IWebElement ResizeButtonResizableBoxWithRestriction => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#resizableBoxWithRestriction > span")));
    }
}
