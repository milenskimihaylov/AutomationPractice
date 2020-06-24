

using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.Pages
{
    public class SoftUniModuleQaAssurancePage : BasePage
    {
        public SoftUniModuleQaAssurancePage(IWebDriver driver)
            :base(driver)
        {
        }

        public IWebElement QAModuleAutomationCourse => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(@href, 'qa-automation-may-2020')]/div[@class='box-content']")));
    }
}
