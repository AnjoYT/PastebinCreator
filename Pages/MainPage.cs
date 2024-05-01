using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PastebinCreator.Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly string url = "https://pastebin.com";
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        protected MainPageElementMap Map
        {
            get
            {
                return new MainPageElementMap(this.driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate(url);
        }
        public void CheckAndHandlePrivacy()
        {
            string className = "css-47sehv";
            wait.Until(By.ClassName(className));
            Map.PrivacyCheckButton.Click();

        }
        public void CreateNewPaste()
        {
            Map.CreatePasteButton.Click();
        }
        public void EnterCode(string text)
        {
            driver.ScrollToElement(Map.CodeFormLocator);
            Map.CodeFormLocator.SendKeys(text);
        }

        public void PickExpirationDate(string text)
        {
            driver.ScrollToElement(Map.PasteExpirationLocator);
            By locator = By.CssSelector("li[class *='select2-results__option']");
            Map.PasteExpirationLocator.Click();
            driver.ClickElementFromDropDown(locator, text);
        }
        public void AddTitle(string text)
        {
            driver.ScrollToElement(Map.PasteTitle);
            Map.PasteTitle.SendKeys(text);
        }

    }
}
