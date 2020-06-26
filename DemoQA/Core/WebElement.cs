using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;

namespace DemoQA.Core
{
    public class WebElement
    {
        public IWebDriver WrappedDriver { get; }

        public IWebElement WrappedElement { get; }

        public By By { get; }

        private WebDriverWait Wait => new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(30));

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            WrappedDriver = webDriver;
            WrappedElement = webElement;
            By = by;
        }

        public void TypeText(string text)
        {
            Debug.WriteLine($"Text {text} is weritten in element with locator {By}");
            WrappedElement.Clear();
            WrappedElement.SendKeys(text);
        }

        public string Text => WrappedElement?.Text;

        public string TagName => WrappedElement?.TagName;

        public bool? Enabled => WrappedElement?.Enabled;

        public bool? Displayed => WrappedElement?.Displayed;

        public bool? Selected => WrappedElement?.Selected;

        public Size Size => WrappedElement.Size;

        public Point Location => WrappedElement.Location;

        public void Click()
        {
            WaitToBeClickable(By);
            WrappedElement?.Click();
        }

        public string GetAttribute(string attributeName)
        {
            return WrappedElement?.GetAttribute(attributeName);
        }

        public string GetCssValue(string cssAttribute)
        {
            return WrappedElement?.GetCssValue(cssAttribute);
        }

        public string GetProperty(string property)
        {
            return WrappedElement?.GetProperty(property);
        }

        public void ConvertToString()
        {
            WrappedElement?.ToString();
        }

        public WebElement FindElement(By by)
        {
            IWebElement nativeWebElement = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, by);

            return element;
        }
        public List<WebElement> FindElements(By by)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new WebElement(WrappedDriver, nativeWebElement, by);
                elements.Add(element);
            }

            return elements;
        }

        private void WaitToBeClickable(By by)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
