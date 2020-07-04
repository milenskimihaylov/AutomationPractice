using DemoQA.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Pages.DemoQA
{
    public class AccordianPage: BasePage
    {
        public AccordianPage(WebDriver driver)
            :base (driver)
        {
        }

        public string URL { get { return "http://demoqa.com/accordian"; } }

        public WebElement AccordionSection(string section) => Driver.FindClickableElement(By.XPath($"//div[@class = 'card']//div[text()='{section}']"));

        public WebElement DivContainingText(int number) => Driver.FindExistingElement(By.XPath($"//div[@id = 'section{number}Heading']/following-sibling::div"));

        public WebElement TextParagraph(int section) => Driver.FindVisibleElement(By.XPath($"//div[@id = 'section{section}Heading']/following-sibling::div//p"));

    }
}
