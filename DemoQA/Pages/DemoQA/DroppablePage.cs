using OpenQA.Selenium;
using System.Threading;

namespace DemoQA.Pages.DemoQA
{
    public class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/droppable"; } }

        public IWebElement TabSimple => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='droppableExample-tab-simple']")));

        public IWebElement DragBox => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("draggable")));

        public IWebElement DropBoxTabSimple => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("droppable")));

        public IWebElement TabAccept => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='droppableExample-tab-accept']")));

        public IWebElement DragBoxNotAcceptable => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("notAcceptable")));

        public IWebElement DropBoxTabAccept => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='acceptDropContainer']/*[2]")));

        public IWebElement TabPreventPropagation => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='droppableExample-tab-preventPropogation']")));

        public IWebElement DragBoxWillRevert => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("revertable")));

        public IWebElement DropBoxTabRevert => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='revertableDropContainer']/*[2]")));

        public IWebElement TabRevertDraggable => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='droppableExample-tab-revertable']")));
    }
}
