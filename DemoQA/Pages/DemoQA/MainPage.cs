using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/"; } }
        public IWebElement SectionCard(string cardName)
        {
            return Wait.Until(d => d.FindElement(By.XPath($"//div[@class='card-body']/h5[text()='{cardName}']")));
        }
    }
}
