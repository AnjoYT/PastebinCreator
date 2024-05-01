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

        protected MainPageElementMap Map => new MainPageElementMap(this.driver);


        public void Navigate()
        {
            driver.Navigate(url);
        }
        public void CheckAndHandlePrivacy()
        {
            wait.Until(Map.PrivacyButtonSelector);
            Map.PrivacyCheckButton.Click();

        }
        public void CreateNewPaste()
        {
            Map.CreateNewPasteButton.Click();
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
            driver.ClickElementFromDropDown(Map.DropDownItems, text);
        }
        public void AddTitle(string text)
        {
            driver.ScrollToElement(Map.PasteTitle);
            Map.PasteTitle.SendKeys(text);
        }
        public void SetSyntax(string text)
        {
            driver.ScrollToElement(Map.SyntaxHighlight);
            Map.SyntaxHighlight.Click();
            driver.ClickElementFromDropDown(Map.DropDownItems, text);
        }
        public void SubmitNewPaste()
        {
            Map.SubmitNewPasteButton.Submit();
        }

    }
}
