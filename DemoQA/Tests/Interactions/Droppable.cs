using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Drawing;
using System.Threading;

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
            Driver.GoToUrl(_droppablePage.URL);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenshot(@"..\..\..\");
            }

            Driver.Quit();
        }

        [Test]
        public void DragAndDropElementWithinABox()
        {
            _droppablePage.TabSimple.Click();
            string[] dropBoxColorBefore = GetBackgroundColor(_droppablePage.DropBoxTabSimple);

            Builder.DragAndDrop(_droppablePage.DragBox.WrappedElement, _droppablePage.DropBoxTabSimple.WrappedElement).Perform();

            string[] dropBoxColorAfter = GetBackgroundColor(_droppablePage.DropBoxTabSimple);

            Assert.AreNotEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
        [Test]
        public void DragAndDropElementThatIsNotAccepted()
        {
            _droppablePage.TabAccept.Click();
            string[] dropBoxColorBefore = GetBackgroundColor(_droppablePage.DropBoxTabAccept);

            Builder.DragAndDrop(_droppablePage.DragBoxNotAcceptable.WrappedElement, _droppablePage.DropBoxTabAccept.WrappedElement).Perform();

            string[] dropBoxColorAfter = GetBackgroundColor(_droppablePage.DropBoxTabAccept);

            Assert.AreEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
        [Test]
        public void DragAndDropElementThatWillRevertToItsFirstLocation()
        {
            _droppablePage.TabRevertDraggable.Click();
            Point dragBoxWillRevertLocationBefore = ElementLocation(_droppablePage.DragBoxWillRevert);
            string[] dropBoxColorBefore = GetBackgroundColor(_droppablePage.DropBoxTabRevert);

            Builder.DragAndDrop(_droppablePage.DragBoxWillRevert.WrappedElement, _droppablePage.DropBoxTabRevert.WrappedElement).Perform();

            Driver.FindExistingElement(By.XPath("//div[@id='revertable' and not(contains(@class,'ui-draggable-dragging'))]")); // wait for the state of the drag box when it wont be moving -> the div class ends with "handle"
            Point dragBoxWillRevertLocationAfter = ElementLocation(_droppablePage.DragBoxWillRevert);
            string[] dropBoxColorAfter = GetBackgroundColor(_droppablePage.DropBoxTabRevert);

            Assert.AreEqual(dragBoxWillRevertLocationBefore, dragBoxWillRevertLocationAfter);
            Assert.AreNotEqual(dropBoxColorBefore, dropBoxColorAfter);
        }
    }
}
