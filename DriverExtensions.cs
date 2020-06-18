using System;

public static class DriverExtensions
{
    public static void ScrollToPixels(IWebDriver driver, int pixels)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy(0, {pixels})");
    }
}
