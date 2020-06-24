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
            Driver.Navigate().GoToUrl(_draggablePage.URL);
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
            Point locationBefore = _draggablePage.DragBoxSimple.Location;

            Builder.DragAndDropToOffset(_draggablePage.DragBoxSimple, 100, 100).Perform();

            Point locationAfter = _draggablePage.DragBoxSimple.Location;

            Assert.AreEqual(locationAfter.X, locationBefore.X + 100);
            Assert.AreEqual(locationAfter.Y, locationBefore.Y + 100);
        }
        [Test]
        public void DragAnElementWithAxisYRestricted()
        {
            _draggablePage.TabAxisRestricted.Click();
            Point locationBefore = _draggablePage.DragBoxOnlyX.Location;

            Builder.DragAndDropToOffset(_draggablePage.DragBoxOnlyX, 100, 100).Perform();

            Point locationAfter = _draggablePage.DragBoxOnlyX.Location;

            Assert.AreEqual(locationAfter.X, locationBefore.X + 100);
            Assert.AreEqual(locationAfter.Y, locationBefore.Y);
        }
        [Test]
        public void DragAnElementWithAxisXRestricted()
        {
            _draggablePage.TabAxisRestricted.Click();
            Point locationBefore = _draggablePage.DragBoxOnlyY.Location;

            Builder.DragAndDropToOffset(_draggablePage.DragBoxOnlyY, 100, 100).Perform();

            Point locationAfter = _draggablePage.DragBoxOnlyY.Location;

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

            Builder.DragAndDropToOffset(_draggablePage.DragBoxWithinContainer, 550, 200).Perform(); // trying to drag the box out of the container

            Point rigthBottomCornerDragBoxAfter = RectangleRightBottomCornerCoordinates(_draggablePage.DragBoxWithinContainer); // finding the coordinates of the right bottom corner of the drag box after dragging it

            Assert.IsTrue(rigthBottomCornerDragBoxAfter.X < rightBottomCornerContainer.X, "Check if the right bottom corner X coordinate of the drag box is within the container box after trying to drag it out of the container");
            Assert.IsTrue(rigthBottomCornerDragBoxAfter.Y < rightBottomCornerContainer.Y, "Check if the right bottom corner Y coordinate of the drag box is within the container box after trying to drag it out of the container");

        }

    }

     
}
