
using AutomationPractice.Pages;
using DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class SoftUniTests : BaseTest
    {
        private SoftUniCoursesPage _softUniCoursesPage;
        private SoftUniModuleQaAssurancePage _softUniModuleQaAssurancePage;
        private QaAutomationCoursePage _qaAutomationCoursePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://www.softuni.bg");
            _softUniCoursesPage = new SoftUniCoursesPage(Driver);
            _softUniModuleQaAssurancePage = new SoftUniModuleQaAssurancePage(Driver);
            _qaAutomationCoursePage = new QaAutomationCoursePage(Driver);
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
        public void SoftUniQAAutomationCourse()
        {
            _softUniCoursesPage.CourseNavigation();

            Driver.ScrollToElement(_softUniModuleQaAssurancePage.QAModuleAutomationCourse).Click();

            IWebElement QaAutomationCourseHeading = _qaAutomationCoursePage.H1Title;

            _qaAutomationCoursePage.AssertH1Title(QaAutomationCourseHeading);

        }
    }
}
