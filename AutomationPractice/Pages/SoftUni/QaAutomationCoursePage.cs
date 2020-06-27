

using DemoQA.Core;
using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    [TestFixture]
    public class QaAutomationCoursePage : BasePage
    {
        public QaAutomationCoursePage(WebDriver driver)
            :base(driver)
        {
        }
        public WebElement H1Title => Driver.FindVisibleElement(By.TagName("h1"));

        public void AssertH1Title(WebElement element)
        {
            Assert.IsTrue(element.Text.Contains("QA Automation - май 2020"), "Check if the h1 heading contains the predefined string.");
        }
    }
}
