using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class DraggablePage : BasePage
    {
        public DraggablePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/dragabble"; } }

        public WebElement TabSimple => Driver.FindExistingElement(By.XPath("//a[@id='draggableExample-tab-simple']"));

        public WebElement DragBoxSimple => Driver.FindClickableElement(By.XPath("//div[text()='Drag me']"));

        public WebElement TabAxisRestricted => Driver.FindExistingElement(By.XPath("//a[@id='draggableExample-tab-axisRestriction']"));

        public WebElement DragBoxOnlyX => Driver.FindClickableElement(By.Id("restrictedX"));

        public WebElement DragBoxOnlyY => Driver.FindClickableElement(By.Id("restrictedY"));

        public WebElement TabContainerRestricted => Driver.FindExistingElement(By.XPath("//a[@id='draggableExample-tab-containerRestriction']"));

        public WebElement ContainerBox => Driver.FindExistingElement(By.Id("containmentWrapper"));

        public WebElement DragBoxWithinContainer => Driver.FindClickableElement(By.XPath("//div[text()=\"I'm contained within the box\"]"));

        public WebElement TabCursorStyle => Driver.FindExistingElement(By.XPath("//a[@id='draggableExample-tab-cursorStyle']"));
    }
}
