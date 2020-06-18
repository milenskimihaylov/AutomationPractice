
using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace AutomationPractice.Pages
{
    public class SoftUniMainPage : BasePage
    {
        public SoftUniMainPage(IWebDriver driver)
            :base(driver)
        {
        }

        public List<IWebElement> NavigationBarTrainings => Wait.Until(d => d.FindElements(By.XPath("//ul[contains(@class, 'nav-list horizontal-list')]/li")).ToList());
    }
}
