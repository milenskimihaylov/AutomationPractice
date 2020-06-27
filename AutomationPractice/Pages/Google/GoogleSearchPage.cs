using DemoQA.Core;
using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(WebDriver driver)
            :base(driver)
        {
        }
        
        public WebElement GoogleSearchTextField => Driver.FindElement(By.XPath("//input[contains(@class, 'gLFyf gsfi')]"));

        public WebElement FirstGoogleSearchResult => Driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div[1]/a"));

        public void AssertPageURL (WebDriver driver)
        {
            Assert.AreEqual("https://www.selenium.dev/", driver.Url(), "Check if the URL of the first website in the search matches the one from the Exercise document.");
        }
        
        public void AssertPageTitle(WebDriver driver)
        {
            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title(), "Check if the title of the first website in the search matches the one from the Exercise document.");
        }
    }
}
