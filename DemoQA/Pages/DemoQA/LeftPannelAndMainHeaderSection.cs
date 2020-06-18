using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class LeftPannelAndMainHeaderSection : BasePage
    {
        public LeftPannelAndMainHeaderSection(IWebDriver driver)
            :base(driver)
        {
        }

        public IWebElement MainHeader => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='main-header']")));

        public IWebElement SectionLeftPannel(string section)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//div[@class='header-text' and text()='{section}']")));
        }

        public IWebElement InteractionsSection(string section)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//li/span[text()='{section}']")));
        }

        public void AssertSection(string expectedSection, string actualSection)
        {
            Assert.AreEqual(expectedSection, actualSection, "Check if the actual section is the expexted one.");
        }
    }
}
