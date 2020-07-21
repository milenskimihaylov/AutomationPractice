using DemoQA.Core;
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
    public class BaseTest
    {
        protected WebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

        protected SelectElement Select { get; set; }

        protected IJavaScriptExecutor JS { get; set; }

        public void Initialize()
        {
            Driver = new WebDriver();
            Driver.Start(Browser.Chrome);
            Builder = new Actions(Driver.WrappedDriver);
            JS = (IJavaScriptExecutor)Driver.WrappedDriver;            
            Driver.WrappedDriver.Manage().Window.Maximize();
        }

        public void TakeScreenshot(string relativePath)
        {
            string dirPath = Path.GetFullPath(@relativePath, Directory.GetCurrentDirectory());
            Thread.Sleep(500);
            var screenshot = ((ITakesScreenshot)Driver.WrappedDriver).GetScreenshot();
            string testName = TestContext.CurrentContext.Test.Name.Replace("\"", "");
            screenshot.SaveAsFile($"{dirPath}\\Screenshots\\{testName}_{DateTime.Now:ddMMyy-HH_mm}.png", ScreenshotImageFormat.Png);
        }

        public void SelectElementFromList(WebElement element, string option)
        {
            Builder.MoveToElement(element.WrappedElement).Click();
            Select = new SelectElement(element.WrappedElement);
            Select.SelectByValue(option);
        }

        public Point ElementLocation(WebElement element)
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

        public Point RectangleRightBottomCornerCoordinates(WebElement element)
        {
            Point rightBottomCornerCoordinates = new Point
            {
                X = element.Location.X + element.Size.Width,
                Y = element.Location.Y + element.Size.Height
            };
            return rightBottomCornerCoordinates;
        }

        public string[] GetBackgroundColor(params WebElement[] pageElement)
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