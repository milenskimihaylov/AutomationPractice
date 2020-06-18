
using DemoQA.Pages;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class AutomationPracticeLoginPage : BasePage
    {
        public AutomationPracticeLoginPage(IWebDriver driver)
            :base(driver)
        {
        }
        public IWebElement EmailAddressTextBox => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("email_create")));

        public IWebElement CreateAnAccountButton => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("SubmitCreate")));        
    }
}
