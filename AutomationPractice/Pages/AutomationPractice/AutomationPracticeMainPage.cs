using DemoQA.Pages;
using OpenQA.Selenium;

namespace POM_Exercises
{
    public class AutomationPracticeMainPage : BasePage
    {
        public AutomationPracticeMainPage(IWebDriver driver)
            :base(driver)
        {
        }
        public IWebElement SignInButton => Wait.Until(d => d.FindElement(By.XPath("//a[@class='login']")));
    }
}