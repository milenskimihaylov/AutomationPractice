
using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AutomationPractice.Pages
{
    public class SoftUniCoursesPage : BasePage
    {
        public SoftUniCoursesPage(IWebDriver driver)
            :base(driver)
        {
        }

        //public IWebElement QaAutomationCourse => Wait.Until(d => d.FindElement(By.XPath("//a[text()='QA Automation - май 2020']")));
        public List<IWebElement> ActiveModules => Wait.Until(d => d.FindElements(By.XPath("//div[contains(@class,'category-title sub uppercase my-collapsible-header')]")).ToList());

        public IWebElement QualityAssuranceModule => Wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Quality Assurance - октомври 2019')]")));
        
    }
}
