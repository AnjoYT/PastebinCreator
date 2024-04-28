using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PastebinCreator
{
    public static class HelperMethods
    {
        public static void Click(this IWebElement locator)
        {
            locator.Click();
        }
        public static void Navigate(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void Until(this WebDriverWait wait, By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
        }
        public static void EnterText(this IWebElement locator, string text)
        {
            locator.SendKeys(text);
        }

    }
}
