using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Tests.Navigation
{
    [TestFixture]
    public class DemoQANavigationTests : BaseTest
    {
        private MainPage _demoQAMainPage;
        private LeftPannelAndMainHeaderSection _leftPannelAndMainHeader;

        [SetUp]
        public void SetUp()
        {
            Initialize(); 
            _demoQAMainPage = new MainPage(Driver);
            Driver.Navigate().GoToUrl(_demoQAMainPage.URL);
            _leftPannelAndMainHeader = new LeftPannelAndMainHeaderSection(Driver);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
        [Test]
        [TestCase("Elements")]
        [TestCase("Forms")]
        [TestCase("Alerts, Frame & Windows")]
        [TestCase("Widgets")]
        [TestCase("Interactions")]
        public void NavigationMainPage(string section)
        {
            string sectionName = _demoQAMainPage.SectionCard(section).Text;

            Driver.ScrollToElement(_demoQAMainPage.SectionCard(section)).Click();

            _leftPannelAndMainHeader.AssertSection(section, sectionName);
        }
        [Test]
        [TestCase("Sortable")]
        [TestCase("Selectable")]
        [TestCase("Resizable")]
        [TestCase("Droppable")]
        [TestCase("Dragabble")]
        public void NavigationInteractionsSection(string section)
        {
            Driver.ScrollToElement(_demoQAMainPage.SectionCard("Interactions")).Click();
            string interactionsSectionName = _leftPannelAndMainHeader.InteractionsSection(section).Text;

            Driver.ScrollToElement(_leftPannelAndMainHeader.InteractionsSection(section)).Click();

            _leftPannelAndMainHeader.AssertSection(section, interactionsSectionName);
        }
    }
}
