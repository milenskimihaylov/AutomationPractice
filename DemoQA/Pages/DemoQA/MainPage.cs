using DemoQA.Core;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class MainPage : BasePage
    {
        public MainPage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/"; } }
        public WebElement SectionCard(string cardName)
        {
            return Driver.FindExistingElement(By.XPath($"//div[@class='card-body']/h5[text()='{cardName}']"));
        }
    }
}
