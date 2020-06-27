
using DemoQA.Core;
using DemoQA.Pages;
using OpenQA.Selenium;
using POM_Exercises;

namespace AutomationPractice.Pages
{
    public class AutomationPracticeLoginPage : BasePage
    {
        public AutomationPracticeLoginPage(WebDriver driver)
            :base(driver)
        {
        }
        public WebElement EmailAddressTextBox => Driver.FindClickableElement(By.Id("email_create"));

        public WebElement CreateAnAccountButton => Driver.FindClickableElement(By.Id("SubmitCreate"));
        
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
