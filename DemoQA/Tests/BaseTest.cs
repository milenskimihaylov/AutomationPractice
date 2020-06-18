using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace DemoQA
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected SelectElement Select { get; set; }

        protected IJavaScriptExecutor JS { get; set; }

        public void Initialize()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Builder = new Actions(Driver);
            JS = (IJavaScriptExecutor)Driver;            
            Driver.Manage().Window.Maximize();
        }
        public void TypeInInputField(IWebElement element, string input)
        {
            element.Clear();
            element.SendKeys(input);
        }

        public void SelectElementFromList(IWebElement element, string option)
        {
            Builder.MoveToElement(element).Click();
            Select = new SelectElement(element);
            Select.SelectByValue(option);
        }

        public Point ElementLocation(IWebElement element)
        {
            Point Location = element.Location;
            return Location;
        }

        public bool LocationIsDifferent(Point locationBefore, Point locationAfter)
        {
            if(locationBefore.X == locationAfter.X && locationBefore.Y == locationAfter.Y)
            {
                return false;

            } else
            {
                return true;
            }
        }

        public Point RectangleRightBottomCornerCoordinates(IWebElement element)
        {
            Point rightBottomCornerCoordinates = new Point
            {
                X = element.Location.X + element.Size.Width,
                Y = element.Location.Y + element.Size.Height
            };
            return rightBottomCornerCoordinates;
        }
    }
}