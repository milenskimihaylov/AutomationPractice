using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class DroppablePage : BasePage
    {
        public DroppablePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/droppable"; } }

        public WebElement TabSimple => Driver.FindExistingElement(By.XPath("//a[@id='droppableExample-tab-simple']"));

        public WebElement DragBox => Driver.FindClickableElement(By.Id("draggable"));

        public WebElement DropBoxTabSimple => Driver.FindClickableElement(By.Id("droppable"));

        public WebElement TabAccept => Driver.FindExistingElement(By.XPath("//a[@id='droppableExample-tab-accept']"));

        public WebElement DragBoxNotAcceptable => Driver.FindClickableElement(By.Id("notAcceptable"));

        public WebElement DropBoxTabAccept => Driver.FindClickableElement(By.XPath("//div[@id='acceptDropContainer']/*[2]"));

        public WebElement TabPreventPropagation => Driver.FindExistingElement(By.XPath("//a[@id='droppableExample-tab-preventPropogation']"));

        public WebElement DragBoxWillRevert => Driver.FindClickableElement(By.Id("revertable"));

        public WebElement DropBoxTabRevert => Driver.FindClickableElement(By.XPath("//div[@id='revertableDropContainer']/*[2]"));

        public WebElement TabRevertDraggable => Driver.FindExistingElement(By.XPath("//a[@id='droppableExample-tab-revertable']"));
    }
}
