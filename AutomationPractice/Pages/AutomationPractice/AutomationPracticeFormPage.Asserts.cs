using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public partial class AutomationPracticeFormPage : BasePage
    {
        public void AssertCorrectEmail(IWebElement element, string email)
        {
            Assert.IsTrue(element.GetAttribute("value").Equals(email), "Check if the value of the textbox has changed and equals to the filled in email address.");
        }

        public void AssertPageSourceDoesNotContain(string pageSource, string text)
        {
            Assert.IsFalse(pageSource.Contains(text));
        }

        public void AssertPageSourceContains(string pageSource, string text)
        {
            Assert.IsTrue(pageSource.Contains(text));
        }
    }
}
