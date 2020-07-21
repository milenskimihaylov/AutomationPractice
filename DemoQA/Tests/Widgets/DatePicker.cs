using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Tests.Widgets
{
    [TestFixture]
    public class DatePicker : BaseTest
    {
        private DatePickerPage _datePickerPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _datePickerPage = new DatePickerPage(Driver);
            Driver.GoToUrl(_datePickerPage.URL);
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
        [TestCase("January")]
        [TestCase("February")]
        [TestCase("March")]
        [TestCase("April")]
        [TestCase("May")]
        [TestCase("June")]
        [TestCase("July")]
        [TestCase("August")]
        [TestCase("September")]
        [TestCase("October")]
        [TestCase("November")]
        [TestCase("December")]
        public void DatePickAllMonthsOfTheYear(string month)
        {
            _datePickerPage.SelectDateInput.SendKeys(Keys.Control + "a" + Keys.Backspace);
            _datePickerPage.SelectMonthDropdown.Click();
            _datePickerPage.MonthOption(month).Click();

            var random = new Random();
            var randomDayOfTheMonth = random.Next(_datePickerPage.DayOption.Count);

            _datePickerPage.DayOption[randomDayOfTheMonth].Click();
            _datePickerPage.SelectDateInput.Click();

            Assert.AreEqual(_datePickerPage.CalendarTitle.Text, $"{month} 2020");
            _datePickerPage.AssertCorrectDayOfTheMonthIsSelected(randomDayOfTheMonth);
        }
    }
}
