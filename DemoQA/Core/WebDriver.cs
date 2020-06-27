using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DemoQA.Core
{
    public class WebDriver
    {
        private WebDriverWait _webDriverWait;
        public IWebDriver WrappedDriver { get; private set; }

        public void Start(Browser browser)
        {
            WrappedDriver = browser switch
            {
                Browser.Chrome => new ChromeDriver(Environment.CurrentDirectory),
                Browser.Firefox => new FirefoxDriver(Environment.CurrentDirectory),
                Browser.Edge => new EdgeDriver(Environment.CurrentDirectory),
                Browser.Opera => new OperaDriver(Environment.CurrentDirectory),
                Browser.Safari => new SafariDriver(Environment.CurrentDirectory),
                Browser.InternetExplorer => new InternetExplorerDriver(Environment.CurrentDirectory),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null),
            };
            _webDriverWait = new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(30));
        }

        public void Quit()
        {
            WrappedDriver.Quit();
        }

        public void GoToUrl(string url)
        {
            WrappedDriver.Navigate().GoToUrl(url);
        }

        public string PageSource()
        {
            return WrappedDriver.PageSource;
        }

        public string Url()
        {
            return WrappedDriver.Url;
        }

        public string Title()
        {
            return WrappedDriver.Title;
        }

        public void ConvertToString()
        {
            WrappedDriver.ToString();
        }

        public WebElement FindElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(d => d.FindElement(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindExistingElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindClickableElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindVisibleElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public List<WebElement> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }
    }
}
