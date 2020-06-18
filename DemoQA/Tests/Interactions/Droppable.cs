using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Droppable : BaseTest
    {
        private DroppablePage _droppablePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _droppablePage = new DroppablePage(Driver);
            Driver.Navigate().GoToUrl(_droppablePage.URL);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void DragAndDropElementWithinABox()
        {
            _droppablePage.TabSimple.Click();
            string dropBoxColorBefore = _droppablePage.DropBoxTabSimple.GetCssValue("background-color");

            Builder.DragAndDrop(_droppablePage.DragBox, _droppablePage.DropBoxTabSimple).Perform();

            string dropBoxColorAfter = _droppablePage.DropBoxTabSimple.GetCssValue("background-color");

            Assert.AreNotEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
        [Test]
        public void DragAndDropElementThatIsNotAccepted()
        {
            _droppablePage.TabAccept.Click();
            string dropBoxColorBefore = _droppablePage.DropBoxTabAccept.GetCssValue("background-color");

            Builder.DragAndDrop(_droppablePage.DragBoxNotAcceptable, _droppablePage.DropBoxTabAccept).Perform();

            string dropBoxColorAfter = _droppablePage.DropBoxTabAccept.GetCssValue("background-color");

            Assert.AreEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
        [Test]
        public void DragAndDropElementThatWillRevertToItsFirstLocation()
        {
            _droppablePage.TabRevertDraggable.Click();
            Point dragBoxWillRevertLocationBefore = _droppablePage.DragBoxWillRevert.Location;
            string dropBoxColorBefore = _droppablePage.DropBoxTabRevert.GetCssValue("background-color");

            Builder.DragAndDrop(_droppablePage.DragBoxWillRevert, _droppablePage.DropBoxTabRevert).Perform();

            Wait.Until(d => d.FindElement(By.Id("revertable")).GetAttribute("class").EndsWith("handle")); // wait for the state of the drag box when it wont be moving -> the div class ends with "handle"
            Point dragBoxWillRevertLocationAfter = _droppablePage.DragBoxWillRevert.Location;
            string dropBoxColorAfter = _droppablePage.DropBoxTabRevert.GetCssValue("background-color");

            Assert.AreEqual(dragBoxWillRevertLocationBefore, dragBoxWillRevertLocationAfter);
            Assert.AreNotEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
    }
}
