using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Drawing;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Sortable : BaseTest
    {
        private SortablePage _sortablePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _sortablePage = new SortablePage(Driver);
            Driver.GoToUrl(_sortablePage.URL);
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
        [TestCase("One", "Two")]
        [TestCase("Two", "Three")]
        [TestCase("Three", "Four")]
        [TestCase("Four", "Five")]
        [TestCase("Five", "Six")]
        public void SortElementsFromAList(string firstElement, string secondElement)
        {
            _sortablePage.TabList.Click();
            Point upperLeftCornerFirstElementBefore = ElementLocation(_sortablePage.ListElement(firstElement));
            Point upperLeftCornerSecondElementBefore = ElementLocation(_sortablePage.ListElement(secondElement));
            Point rightBottomCornerFirstElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(firstElement));
            Point rightBottomCornerSecondElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(secondElement));

            Builder.DragAndDropToOffset(_sortablePage.ListElement(firstElement).WrappedElement, 0, 49).Perform(); // the height of the element is 49px

            Point upperLeftCornerFirstElementAfter = ElementLocation(_sortablePage.ListElement(firstElement));
            Point upperLeftCornerSecondElementAfter = ElementLocation(_sortablePage.ListElement(secondElement));
            Point rightBottomCornerFirstElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(firstElement));
            Point rightBottomCornerSecondElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(secondElement));

            Assert.AreEqual(upperLeftCornerFirstElementAfter, upperLeftCornerSecondElementBefore);
            Assert.AreEqual(upperLeftCornerSecondElementAfter, upperLeftCornerFirstElementBefore);
            Assert.AreEqual(rightBottomCornerFirstElementAfter, rightBottomCornerSecondElementBefore);
            Assert.AreEqual(rightBottomCornerSecondElementAfter, rightBottomCornerFirstElementBefore);
        }
        [Test]
        [TestCase("One", "Two")]
        [TestCase("Two", "Three")]
        [TestCase("Four", "Five")]
        [TestCase("Five", "Six")]
        [TestCase("Seven", "Eight")]
        [TestCase("Eight", "Nine")]
        public void SortElementsFromAGrid(string firstElement, string secondElement)
        {
            _sortablePage.TabGrid.Click();
            Point upperLeftCornerFirstElementBefore = ElementLocation(_sortablePage.GridElement(firstElement));
            Point upperLeftCornerSecondElementBefore = ElementLocation(_sortablePage.GridElement(secondElement));
            Point rightBottomCornerFirstElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(firstElement));
            Point rightBottomCornerSecondElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(secondElement));

            Builder.DragAndDropToOffset(_sortablePage.GridElement(firstElement).WrappedElement, 100, 0).Perform(); // the width of the element is 100px

            Point upperLeftCornerFirstElementAfter = ElementLocation(_sortablePage.GridElement(firstElement));
            Point upperLeftCornerSecondElementAfter = ElementLocation(_sortablePage.GridElement(secondElement));
            Point rightBottomCornerFirstElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(firstElement));
            Point rightBottomCornerSecondElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(secondElement));

            Assert.AreEqual(upperLeftCornerFirstElementAfter, upperLeftCornerSecondElementBefore);
            Assert.AreEqual(upperLeftCornerSecondElementAfter, upperLeftCornerFirstElementBefore);
            Assert.AreEqual(rightBottomCornerFirstElementAfter, rightBottomCornerSecondElementBefore);
            Assert.AreEqual(rightBottomCornerSecondElementAfter, rightBottomCornerFirstElementBefore);
        }
    }
}
