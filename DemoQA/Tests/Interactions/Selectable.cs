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
            string[] elementsBackgroundColorBefore = GetBackgroundColor(_selectablePage.ElementFromTheList(1), 
                                                                  _selectablePage.ElementFromTheList(2), 
                                                                  _selectablePage.ElementFromTheList(3), 
                                                                  _selectablePage.ElementFromTheList(4));

            _selectablePage.ElementFromTheList(1).Click();
            _selectablePage.ElementFromTheList(2).Click();
            _selectablePage.ElementFromTheList(3).Click();

            string[] elementsBackgroundColorAfter = GetBackgroundColor(_selectablePage.ElementFromTheList(1),
                                                                  _selectablePage.ElementFromTheList(2),
                                                                  _selectablePage.ElementFromTheList(3),
                                                                  _selectablePage.ElementFromTheList(4));

            Assert.AreNotEqual(elementsBackgroundColorBefore[0], elementsBackgroundColorAfter[0]);
            Assert.AreNotEqual(elementsBackgroundColorBefore[1], elementsBackgroundColorAfter[1]);
            Assert.AreNotEqual(elementsBackgroundColorBefore[2], elementsBackgroundColorAfter[2]);
            Assert.AreEqual(elementsBackgroundColorBefore[3], elementsBackgroundColorAfter[3]);
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
            string[] elementsBackgroundColorBefore = GetBackgroundColor(_selectablePage.ElementFromTheGrid("One"),
                                                                        _selectablePage.ElementFromTheGrid("Three"),
                                                                        _selectablePage.ElementFromTheGrid("Five"),
                                                                        _selectablePage.ElementFromTheGrid("Nine"));

            _selectablePage.ElementFromTheGrid("One").Click();
            _selectablePage.ElementFromTheGrid("Five").Click();
            _selectablePage.ElementFromTheGrid("Nine").Click();

            string[] elementsBackgroundColorAfter = GetBackgroundColor(_selectablePage.ElementFromTheGrid("One"),
                                                                        _selectablePage.ElementFromTheGrid("Three"),
                                                                        _selectablePage.ElementFromTheGrid("Five"),
                                                                        _selectablePage.ElementFromTheGrid("Nine"));

            Assert.AreNotEqual(elementsBackgroundColorBefore[0], elementsBackgroundColorAfter[0]);
            Assert.AreEqual(elementsBackgroundColorBefore[1], elementsBackgroundColorAfter[1]);
            Assert.AreNotEqual(elementsBackgroundColorBefore[2], elementsBackgroundColorAfter[2]);
            Assert.AreNotEqual(elementsBackgroundColorBefore[3], elementsBackgroundColorAfter[3]);
        }
    }
}
