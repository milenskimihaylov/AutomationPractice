using DemoQA.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQA.Pages
{
    public class BasePage
    {
        public BasePage(WebDriver driver)
        {
            Driver = driver;
        }
        public WebDriver Driver { get; }

    }


}
