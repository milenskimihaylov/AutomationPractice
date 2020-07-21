using DemoQA.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Pages.DemoQA
{
    public class AutoCompletePage: BasePage
    {
        public AutoCompletePage(WebDriver driver)
            :base(driver)
        {
        }

        public string URL { get { return "http://demoqa.com/auto-complete"; } }

        public WebElement MultipleColorNamesInput => Driver.FindExistingElement(By.XPath("//input[@id='autoCompleteMultipleInput']"));

        public WebElement DivMultipleColors => Driver.FindExistingElement(By.XPath("//div[@id='autoCompleteMultipleContainer']"));

        public WebElement ColorTab(string color) => Driver.FindExistingElement(By.XPath($"//div[contains(@class, 'auto-complete__multi-value__label') and text()='{color}']"));

        public WebElement SingleColorNameInput => Driver.FindExistingElement(By.XPath("//input[@id='autoCompleteSingleInput']"));

        public WebElement RedColorDiv => Driver.FindExistingElement(By.XPath("//div[@id='react-select-3-option-0']"));

        public WebElement GreenColorDiv => Driver.FindExistingElement(By.XPath("//div[@id='react-select-3-option-1']"));
    }
}
