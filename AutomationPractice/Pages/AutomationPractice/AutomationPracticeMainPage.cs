using DemoQA.Core;
using DemoQA.Pages;
using OpenQA.Selenium;

namespace POM_Exercises
{
    public class AutomationPracticeMainPage : BasePage
    {
        public AutomationPracticeMainPage(WebDriver driver)
            :base(driver)
        {
        }
        public WebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));
    }
}