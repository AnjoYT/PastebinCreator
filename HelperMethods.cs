using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PastebinCreator
{
    public static class HelperMethods
    {
        public static void Navigate(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void Until(this WebDriverWait wait, By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
        }
        public static void ClickElementFromDropDown(this IWebDriver driver, By by, string text)
        {
            var elements = driver.FindElements(by);
            IWebElement element = elements.FirstOrDefault(x => x.Text.Equals(text));
            if (element != null)
            {
                element.Click();
            }
        }
        public static void ScrollToElement(this IWebDriver driver, IWebElement locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", locator);
        }
        public static void WaitForPageLoad(this WebDriverWait wait) => wait.Until(condition => ((IJavaScriptExecutor)condition).ExecuteScript("return document.readyState").Equals("complete"));

    }
}
