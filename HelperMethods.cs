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

        public static void HandlePrivacy(this By by, IWebElement locator, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            locator.Click();
        }

        public static bool CompareElements(this string text, IWebElement lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }
            string[] expectedLines = text.Split('\n');
            foreach (var line in lines.FindElements(By.CssSelector("li")))
            {
                string test = line.GetAttribute("innerText");
                string lineWithoutTags = line.GetAttribute("innerText");
                if (!expectedLines.Contains(lineWithoutTags.Trim()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
