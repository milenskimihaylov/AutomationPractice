using DemoQA.Core;
using OpenQA.Selenium;
using System.Threading;

public static class DriverExtensions
{
    public static void ScrollToPixels(this WebDriver driver, int pixels)
    {
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript($"window.scrollBy(0, {pixels})");
    }

    public static WebElement ScrollToElement(this WebDriver driver, WebElement element)
    {
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
        return element;
    }

    public static void HighLight(this WebDriver driver, WebElement element)
    {
        var colorBefore = element.GetCssValue("background-color");
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript("arguments[0].style.backgroundColor = 'green';", element.WrappedElement);
        Thread.Sleep(500);
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript($"arguments[0].style.backgroundColor = '{colorBefore}';", element.WrappedElement);
    }

    /*public static Point MouseCoordinates(this IWebDriver driver)
    {
        Point mouseCoordinates = new Point();
        ((IJavaScriptExecutor)driver).ExecuteScript($"document.addEventListener('mousemove', (e) => {{ {mouseCoordinates.X} = e.pageX, {mouseCoordinates.Y} = e.pageY}});");
        return mouseCoordinates;
    }*/
}

