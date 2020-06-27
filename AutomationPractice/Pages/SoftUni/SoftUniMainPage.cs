
using DemoQA.Core;
using DemoQA.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AutomationPractice.Pages
{
    public class SoftUniMainPage : BasePage
    {
        public SoftUniMainPage(WebDriver driver)
            :base(driver)
        {
        }

        public List<WebElement> NavigationBarTrainings => Driver.FindElements(By.XPath("//ul[contains(@class, 'nav-list horizontal-list')]/li")).ToList();
    }
}
