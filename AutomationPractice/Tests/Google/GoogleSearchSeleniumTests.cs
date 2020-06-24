

using AutomationPractice.Pages;
using DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutomationPractice.Tests
{
    [TestFixture]
    class GoogleSearchSeleniumTests : BaseTest
    {
        private GoogleSearchPage _googleSearchPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://www.google.com");
            _googleSearchPage = new GoogleSearchPage(Driver);
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
        public void GoogleSearchCorrectWebsiteURLandTitle()
        {
            _googleSearchPage.GoogleSearchTextField.SendKeys("selenium" + Keys.Enter);

            _googleSearchPage.FirstGoogleSearchResult.Click();

            _googleSearchPage.AssertPageURL(Driver);
            _googleSearchPage.AssertPageTitle(Driver);
        }
       
    }
}
