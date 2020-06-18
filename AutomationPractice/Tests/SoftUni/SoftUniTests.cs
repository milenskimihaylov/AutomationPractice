
using AutomationPractice.Pages;
using DemoQA;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class SoftUniTests : BaseTest
    {
        private SoftUniMainPage _softUniMainPage;
        private SoftUniCoursesPage _softUniCoursesPage;
        private SoftUniModuleQaAssurancePage _softUniModuleQaAssurancePage;
        private QaAutomationCoursePage _qaAutomationCoursePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://www.softuni.bg");
            _softUniMainPage = new SoftUniMainPage(Driver);
            _softUniCoursesPage = new SoftUniCoursesPage(Driver);
            _softUniModuleQaAssurancePage = new SoftUniModuleQaAssurancePage(Driver);
            _qaAutomationCoursePage = new QaAutomationCoursePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void SoftUniQAAutomationCourse()
        {
            _softUniMainPage.NavigationBarTrainings[1].Click();
            _softUniCoursesPage.ActiveModules[1].Click();
            _softUniCoursesPage.QualityAssuranceModule.Click();

            Driver.ScrollToElement(_softUniModuleQaAssurancePage.QAModuleAutomationCourse).Click();

            IWebElement QaAutomationCourseHeading = _qaAutomationCoursePage.H1Title;

            _qaAutomationCoursePage.AssertH1Title(QaAutomationCourseHeading);

        }
    }
}
