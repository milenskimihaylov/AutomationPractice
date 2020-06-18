using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/dragabble"; } }

        public IWebElement TabSimple => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='draggableExample-tab-simple']")));

        public IWebElement DragBoxSimple => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Drag me']")));

        public IWebElement TabAxisRestricted => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='draggableExample-tab-axisRestriction']")));

        public IWebElement DragBoxOnlyX => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("restrictedX")));

        public IWebElement DragBoxOnlyY => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("restrictedY")));

        public IWebElement TabContainerRestricted => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='draggableExample-tab-containerRestriction']")));

        public IWebElement ContainerBox => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("containmentWrapper")));

        public IWebElement DragBoxWithinContainer => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()=\"I'm contained within the box\"]")));

        public IWebElement TabCursorStyle => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='draggableExample-tab-cursorStyle']")));
    }
}
