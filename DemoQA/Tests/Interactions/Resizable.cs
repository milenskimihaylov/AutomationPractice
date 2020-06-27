using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Drawing;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Resizable : BaseTest
    {
        private ResizablePage _resizablePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _resizablePage = new ResizablePage(Driver);
            Driver.GoToUrl(_resizablePage.URL);
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
        public void ResizeAnElement()
        {
            Point rightBottomCornerOfResizableBoxBefore = RectangleRightBottomCornerCoordinates(_resizablePage.ResizableBox);
            Driver.ScrollToElement(_resizablePage.ResizeButtonResizableBox);

            Builder.DragAndDropToOffset(_resizablePage.ResizeButtonResizableBox.WrappedElement, 100, 100).Perform();

            Point rightBottomCornerOfResizableBoxAfter = RectangleRightBottomCornerCoordinates(_resizablePage.ResizableBox);

            Assert.AreEqual(rightBottomCornerOfResizableBoxAfter.X, rightBottomCornerOfResizableBoxBefore.X + 100);
            Assert.AreEqual(rightBottomCornerOfResizableBoxAfter.Y, rightBottomCornerOfResizableBoxBefore.Y + 100);
        }
        [Test]
        public void ResizeAnElementToItsMinSize()
        {
            Size resizableBoxSizeBefore = _resizablePage.ResizableBoxWithRestriction.Size;

            Builder.DragAndDropToOffset(_resizablePage.ResizeButtonResizableBoxWithRestriction.WrappedElement, -100, -100).Perform();

            Size resizableBoxSizeAfter = _resizablePage.ResizableBoxWithRestriction.Size;

            Assert.AreNotEqual(resizableBoxSizeBefore.Width, resizableBoxSizeAfter.Width);
            Assert.AreNotEqual(resizableBoxSizeBefore.Height, resizableBoxSizeAfter.Height);
            Assert.AreEqual(150, resizableBoxSizeAfter.Width);
            Assert.AreEqual(150, resizableBoxSizeAfter.Height);
        }
    }
}
