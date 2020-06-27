

using DemoQA.Core;
using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.Pages
{
    public class SoftUniModuleQaAssurancePage : BasePage
    {
        public SoftUniModuleQaAssurancePage(WebDriver driver)
            :base(driver)
        {
        }

        public WebElement QAModuleAutomationCourse => Driver.FindClickableElement(By.XPath("//a[contains(@href, 'qa-automation-may-2020')]/div[@class='box-content']"));
    }
}
