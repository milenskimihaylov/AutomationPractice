

using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    [TestFixture]
    public class QaAutomationCoursePage : BasePage
    {
        public QaAutomationCoursePage(IWebDriver driver)
            :base(driver)
        {
        }
        public IWebElement H1Title => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h1")));

        public void AssertH1Title(IWebElement element)
        {
            Assert.IsTrue(element.Text.Contains("QA Automation - май 2020"), "Check if the h1 heading contains the predefined string.");
        }
    }
}
