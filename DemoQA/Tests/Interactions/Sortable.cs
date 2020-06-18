using DemoQA.Pages.DemoQA;
using NUnit.Framework;
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
            Driver.Navigate().GoToUrl(_sortablePage.URL);
        }

        [TearDown]
        public void TearDown()
        {
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
            Point firstElementLocationBefore = _sortablePage.ListElement(firstElement).Location;
            Point secondElementLocationBefore = _sortablePage.ListElement(secondElement).Location;
            Point rightBottomCornerFirstElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(firstElement));
            Point rightBottomCornerSecondElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(secondElement));

            Builder.DragAndDropToOffset(_sortablePage.ListElement(firstElement), 0, 49).Perform(); // the height of the element is 49px

            Point firstElementLocationAfter = _sortablePage.ListElement(firstElement).Location;
            Point secondElementLocationAfter = _sortablePage.ListElement(secondElement).Location;
            Point rightBottomCornerFirstElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(firstElement));
            Point rightBottomCornerSecondElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.ListElement(secondElement));

            Assert.AreEqual(firstElementLocationAfter, secondElementLocationBefore);
            Assert.AreEqual(secondElementLocationAfter, firstElementLocationBefore);
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
            Point firstElementLocationBefore = _sortablePage.GridElement(firstElement).Location;
            Point secondElementLocationBefore = _sortablePage.GridElement(secondElement).Location;
            Point rightBottomCornerFirstElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(firstElement));
            Point rightBottomCornerSecondElementBefore = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(secondElement));

            Builder.DragAndDropToOffset(_sortablePage.GridElement(firstElement), 100, 0).Perform(); // the width of the element is 100px

            Point firstElementLocationAfter = _sortablePage.GridElement(firstElement).Location;
            Point secondElementLocationAfter = _sortablePage.GridElement(secondElement).Location;
            Point rightBottomCornerFirstElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(firstElement));
            Point rightBottomCornerSecondElementAfter = RectangleRightBottomCornerCoordinates(_sortablePage.GridElement(secondElement));

            Assert.AreEqual(firstElementLocationAfter, secondElementLocationBefore);
            Assert.AreEqual(secondElementLocationAfter, firstElementLocationBefore);
            Assert.AreEqual(rightBottomCornerFirstElementAfter, rightBottomCornerSecondElementBefore);
            Assert.AreEqual(rightBottomCornerSecondElementAfter, rightBottomCornerFirstElementBefore);
        }
    }
}
