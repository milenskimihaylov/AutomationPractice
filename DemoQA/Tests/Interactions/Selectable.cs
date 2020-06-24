using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Selectable : BaseTest
    {
        private SelectablePage _selectablePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _selectablePage = new SelectablePage(Driver);
            Driver.Navigate().GoToUrl(_selectablePage.URL);
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
        public void SelectElementFromAList([Range(1, 4)] int elementNumber)
        {
            _selectablePage.TabList.Click();
            string elementColorBefore = _selectablePage.ElementFromTheList(elementNumber).GetCssValue("background-color");

            _selectablePage.ElementFromTheList(elementNumber).Click();

            string elementColorAfter = _selectablePage.ElementFromTheList(elementNumber).GetCssValue("background-color");

            Assert.AreNotEqual(elementColorBefore, elementColorAfter);
        }
        [Test]
        public void SelectMultipleElementsFromAList()
        {
            _selectablePage.TabList.Click();
            string firstElementColorBefore = _selectablePage.ElementFromTheList(1).GetCssValue("background-color");
            string secondElementColorBefore = _selectablePage.ElementFromTheList(2).GetCssValue("background-color");
            string thirdElementColorBefore = _selectablePage.ElementFromTheList(3).GetCssValue("background-color");
            string fourthElementColorBefore = _selectablePage.ElementFromTheList(4).GetCssValue("background-color");

            _selectablePage.ElementFromTheList(1).Click();
            _selectablePage.ElementFromTheList(2).Click();
            _selectablePage.ElementFromTheList(3).Click();

            string firstElementColorAfter = _selectablePage.ElementFromTheList(1).GetCssValue("background-color");
            string secondElementColorAfter = _selectablePage.ElementFromTheList(2).GetCssValue("background-color");
            string thirdElementColorAfter = _selectablePage.ElementFromTheList(3).GetCssValue("background-color");
            string fourthElementColorAfter = _selectablePage.ElementFromTheList(4).GetCssValue("background-color");

            Assert.AreNotEqual(firstElementColorBefore, firstElementColorAfter);
            Assert.AreNotEqual(secondElementColorBefore, secondElementColorAfter);
            Assert.AreNotEqual(thirdElementColorBefore, thirdElementColorAfter);
            Assert.AreEqual(fourthElementColorBefore, fourthElementColorAfter);
        }
        [Test]
        [TestCase("One")]
        [TestCase("Two")]
        [TestCase("Three")]
        [TestCase("Four")]
        [TestCase("Five")]
        [TestCase("Six")]
        [TestCase("Seven")]
        [TestCase("Eight")]
        [TestCase("Nine")]
        public void SelectElementFromAGrid(string element)
        {
            _selectablePage.TabGrid.Click();
            string elementColorBefore = _selectablePage.ElementFromTheGrid(element).GetCssValue("background-color");

            _selectablePage.ElementFromTheGrid(element).Click();

            string elementColorAfter = _selectablePage.ElementFromTheGrid(element).GetCssValue("background-color");

            Assert.AreNotEqual(elementColorBefore, elementColorAfter);
        }
        [Test]
        public void SelectMultipleElementsFromAGrid()
        {
            _selectablePage.TabGrid.Click();
            string firstElementColorBefore = _selectablePage.ElementFromTheGrid("One").GetCssValue("background-color");
            string thirdElementColorBefore = _selectablePage.ElementFromTheGrid("Three").GetCssValue("background-color");
            string fifthElementColorBefore = _selectablePage.ElementFromTheGrid("Five").GetCssValue("background-color");
            string ninthElementColorBefore = _selectablePage.ElementFromTheGrid("Nine").GetCssValue("background-color");

            _selectablePage.ElementFromTheGrid("One").Click();
            _selectablePage.ElementFromTheGrid("Five").Click();
            _selectablePage.ElementFromTheGrid("Nine").Click();

            string firstElementColorAfter = _selectablePage.ElementFromTheGrid("One").GetCssValue("background-color");
            string thirdElementColorAfter = _selectablePage.ElementFromTheGrid("Three").GetCssValue("background-color");
            string fifthElementColorAfter = _selectablePage.ElementFromTheGrid("Five").GetCssValue("background-color");
            string ninthElementColorAfter = _selectablePage.ElementFromTheGrid("Nine").GetCssValue("background-color");

            Assert.AreNotEqual(firstElementColorBefore, firstElementColorAfter);
            Assert.AreEqual(thirdElementColorBefore, thirdElementColorAfter);
            Assert.AreNotEqual(fifthElementColorBefore, fifthElementColorAfter);
            Assert.AreNotEqual(ninthElementColorBefore, ninthElementColorAfter);
        }
    }
}
