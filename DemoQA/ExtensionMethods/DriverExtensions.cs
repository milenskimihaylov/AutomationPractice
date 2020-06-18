using OpenQA.Selenium;
using System.Drawing;
using System.Threading;

public static class DriverExtensions
{
    public static void ScrollToPixels(this IWebDriver driver, int pixels)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy(0, {pixels})");
    }

    public static IWebElement ScrollToElement(this IWebDriver driver, IWebElement element)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        return element;
    }

    public static void HighLight(this IWebDriver driver, IWebElement element)
    {
        var colorBefore = element.GetCssValue("background-color");
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.backgroundColor = 'red';", element);
        Thread.Sleep(500);
        ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].style.backgroundColor = '{colorBefore}';", element);
    }

    /*public static Point MouseCoordinates(this IWebDriver driver)
    {
        Point mouseCoordinates = new Point();
        ((IJavaScriptExecutor)driver).ExecuteScript($"document.addEventListener('mousemove', (e) => {{ {mouseCoordinates.X} = e.pageX, {mouseCoordinates.Y} = e.pageY}});");
        return mouseCoordinates;
    }*/
}

