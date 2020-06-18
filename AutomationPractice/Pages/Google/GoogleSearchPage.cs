using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver)
            :base(driver)
        {
        }
        
        public IWebElement GoogleSearchTextField => Wait.Until(d => d.FindElement(By.XPath("//input[contains(@class, 'gLFyf gsfi')]")));

        public IWebElement FirstGoogleSearchResult => Wait.Until(d => d.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div[1]/a")));

        public void AssertPageURL (IWebDriver driver)
        {
            Assert.AreEqual("https://www.selenium.dev/", driver.Url, "Check if the URL of the first website in the search matches the one from the Exercise document.");
        }
        
        public void AssertPageTitle(IWebDriver driver)
        {
            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title, "Check if the title of the first website in the search matches the one from the Exercise document.");
        }
    }
}
