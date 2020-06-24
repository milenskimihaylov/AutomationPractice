using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;

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

        public void TakeScreenshot(string relativePath)
        {
            string dirPath = Path.GetFullPath(@relativePath, Directory.GetCurrentDirectory());
            Thread.Sleep(500);
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string testName = TestContext.CurrentContext.Test.Name.Replace("\"", "");
            screenshot.SaveAsFile($"{dirPath}\\Screenshots\\{testName}_{DateTime.Now:ddMMyy-HH_mm}.png", ScreenshotImageFormat.Png);
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

        public string[] GetBackgroundColor(params IWebElement[] pageElement)
        {
            int i = 0;
            string[] elementBackgroundColor = new string[pageElement.Length];
            foreach (var element in pageElement)
            {
                elementBackgroundColor[i] = element.GetCssValue("background-color");
                i++;
            }
            return elementBackgroundColor;
        }
    }
}