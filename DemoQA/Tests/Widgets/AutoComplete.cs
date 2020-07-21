using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Threading;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class AutoComplete: BaseTest
    {
        private AutoCompletePage _autoCompletePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _autoCompletePage = new AutoCompletePage(Driver);
            Driver.GoToUrl(_autoCompletePage.URL);
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
        /*
        [Test]
        //[TestCase("Green", "Blue", "Purple")]
        [TestCase("White", "Green", "Red")]
        public void InputMultipleColors(string firstColor, string secondColor, string thirdColor)
        {
            Builder. .Click(_autoCompletePage.MultipleColorNamesInput.WrappedElement).SendKeys(firstColor + Keys.Enter).Perform();
        }
        */
        [Test]
        public void AutoCompleteSingleColorName()
        {
            _autoCompletePage.SingleColorNameInput.SendKeys("re");

            Assert.IsTrue(_autoCompletePage.RedColorDiv.Displayed);
            Assert.IsTrue(_autoCompletePage.GreenColorDiv.Displayed);
            Assert.AreEqual("Red", _autoCompletePage.RedColorDiv.Text);
            Assert.AreEqual("Green", _autoCompletePage.GreenColorDiv.Text);
        }
    }
}
