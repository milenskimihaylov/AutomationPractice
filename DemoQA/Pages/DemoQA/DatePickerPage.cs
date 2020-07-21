using DemoQA.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoQA.Pages.DemoQA
{
    public class DatePickerPage : BasePage
    {
        public DatePickerPage(WebDriver driver) : base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/date-picker"; } }

        public WebElement SelectDateInput => Driver.FindExistingElement(By.XPath("//input[@id='datePickerMonthYearInput']"));

        public WebElement SelectMonthDropdown => Driver.FindExistingElement(By.XPath("//select[@class='react-datepicker__month-select']"));

        public WebElement MonthOption(string month) => Driver.FindExistingElement(By.XPath($"//option[text()='{month}']"));

        public List<WebElement> DayOption => Driver.FindElements(By.XPath("//div[@class='react-datepicker__month']//div[contains(@class, 'react-datepicker__day') and not(contains(@class, 'outside-month'))]")).ToList();

        public WebElement CalendarTitle => Driver.FindExistingElement(By.XPath("//div[contains(@class, 'current-month')]"));

        public void AssertCorrectDayOfTheMonthIsSelected(int dayOfTheMonth)
        {
            Assert.IsTrue(DayOption[dayOfTheMonth].GetAttribute("class").Contains("selected"));
        }
    }
}
