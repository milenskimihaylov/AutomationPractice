using DemoQA.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class LeftPannelAndMainHeaderSection : BasePage
    {
        public LeftPannelAndMainHeaderSection(WebDriver driver)
            :base(driver)
        {
        }

        public WebElement MainHeader => Driver.FindExistingElement(By.XPath("//div[@class='main-header']"));

        public WebElement SectionLeftPannel(string section)
        {
            return Driver.FindExistingElement(By.XPath($"//div[@class='header-text' and text()='{section}']"));
        }

        public WebElement InteractionsSection(string section)
        {
            return Driver.FindExistingElement(By.XPath($"//li/span[text()='{section}']"));
        }

        public void AssertSection(string expectedSection, string actualSection)
        {
            Assert.AreEqual(expectedSection, actualSection, "Check if the actual section is the expexted one.");
        }
    }
}
