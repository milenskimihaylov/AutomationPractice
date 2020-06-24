
using DemoQA.Pages;
using OpenQA.Selenium;
using POM_Exercises;

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
        
        public void GoToCreateAnAccountForm(string email)
        {
            AutomationPracticeMainPage automationPracticeMainPage = new AutomationPracticeMainPage(Driver);
            automationPracticeMainPage.SignInButton.Click();
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(email);
            CreateAnAccountButton.Click();
        }
    }
}
