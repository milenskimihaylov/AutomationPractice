using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Drawing;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Draggable : BaseTest
    {
        private DraggablePage _draggablePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _draggablePage = new DraggablePage(Driver);
            Driver.GoToUrl(_draggablePage.URL);
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
        public void DragAnElement()
        {
            _draggablePage.TabSimple.Click();
            Point locationBefore = ElementLocation(_draggablePage.DragBoxSimple);

            Builder.DragAndDropToOffset(_draggablePage.DragBoxSimple.WrappedElement, 100, 100).Perform();

            Point locationAfter = ElementLocation(_draggablePage.DragBoxSimple);

            Assert.AreEqual(locationAfter.X, locationBefore.X + 100);
            Assert.AreEqual(locationAfter.Y, locationBefore.Y + 100);
        }
        [Test]
        public void DragAnElementWithAxisYRestricted()
        {
            _draggablePage.TabAxisRestricted.Click();
            Point locationBefore = ElementLocation(_draggablePage.DragBoxOnlyX);

            Builder.DragAndDropToOffset(_draggablePage.DragBoxOnlyX.WrappedElement, 100, 100).Perform();

            Point locationAfter = ElementLocation(_draggablePage.DragBoxOnlyX);

            Assert.AreEqual(locationAfter.X, locationBefore.X + 100);
            Assert.AreEqual(locationAfter.Y, locationBefore.Y);
        }
        [Test]
        public void DragAnElementWithAxisXRestricted()
        {
            _draggablePage.TabAxisRestricted.Click();
            Point locationBefore = ElementLocation(_draggablePage.DragBoxOnlyY);

            Builder.DragAndDropToOffset(_draggablePage.DragBoxOnlyY.WrappedElement, 100, 100).Perform();

            Point locationAfter = ElementLocation(_draggablePage.DragBoxOnlyY);

            Assert.AreEqual(locationAfter.X, locationBefore.X);
            Assert.AreEqual(locationAfter.Y, locationBefore.Y + 100);
        }
        [Test]
        public void DragAnElementRestrictedWithinABox()
        {
            _draggablePage.TabContainerRestricted.Click();
            Point rigthBottomCornerDragBoxBefore = RectangleRightBottomCornerCoordinates(_draggablePage.DragBoxWithinContainer); // finding the coordinates of the right bottom corner of the drag box before dragging it
            Point rightBottomCornerContainer = RectangleRightBottomCornerCoordinates(_draggablePage.ContainerBox); // finding the coordinates of the right bottom corner of the container box

            Assert.IsTrue(rigthBottomCornerDragBoxBefore.X < rightBottomCornerContainer.X, "Check if the right bottom corner X coordinate of the drag box is within the container box in the beginning of the test");
            Assert.IsTrue(rigthBottomCornerDragBoxBefore.Y < rightBottomCornerContainer.Y, "Check if the right bottom corner Y coordinate of the drag box is within the container box in the beginning of the test");

            Builder.DragAndDropToOffset(_draggablePage.DragBoxWithinContainer.WrappedElement, 550, 200).Perform(); // trying to drag the box out of the container

            Point rigthBottomCornerDragBoxAfter = RectangleRightBottomCornerCoordinates(_draggablePage.DragBoxWithinContainer); // finding the coordinates of the right bottom corner of the drag box after dragging it

            Assert.IsTrue(rigthBottomCornerDragBoxAfter.X < rightBottomCornerContainer.X, "Check if the right bottom corner X coordinate of the drag box is within the container box after trying to drag it out of the container");
            Assert.IsTrue(rigthBottomCornerDragBoxAfter.Y < rightBottomCornerContainer.Y, "Check if the right bottom corner Y coordinate of the drag box is within the container box after trying to drag it out of the container");

        }

    }

     
}
