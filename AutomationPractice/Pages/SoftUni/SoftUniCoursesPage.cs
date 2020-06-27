
using DemoQA.Core;
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
        public SoftUniCoursesPage(WebDriver driver)
            :base(driver)
        {
        }

        public List<WebElement> ActiveModules => Driver.FindElements(By.XPath("//div[contains(@class,'category-title sub uppercase my-collapsible-header')]")).ToList();

        public WebElement QualityAssuranceModule => Driver.FindElement(By.XPath("//a[contains(text(),'Quality Assurance - октомври 2019')]"));
        
        public void CourseNavigation()
        {
            SoftUniMainPage softUniMainPage = new SoftUniMainPage(Driver);
            softUniMainPage.NavigationBarTrainings[1].Click();
            ActiveModules[1].Click();
            QualityAssuranceModule.Click();
        }
    }
}
