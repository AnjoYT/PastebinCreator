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
            wait.WaitForPageLoad();
        }
        public void CheckAndHandlePrivacy()
        {
            wait.Until(this.Map.PrivacyButtonSelector);
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
            Map.PasteExpirationLocator.Click();
            driver.ClickElementFromDropDown(this.Map.PasteExpitationOptions, text);
        }
        public void AddTitle(string text)
        {
            driver.ScrollToElement(Map.PasteTitle);
            Map.PasteTitle.SendKeys(text);
        }

    }
}
