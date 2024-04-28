using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PastebinCreator.Pages
{
    public class MainPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private readonly string url = "https://pastebin.com";
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        IWebElement CodeForm => driver.FindElement(By.Id("postform-text"));
        SelectElement Category => new SelectElement(driver.FindElement(By.Id("select2-postform-category_id-container")));
        SelectElement PasteExpiration => new SelectElement(driver.FindElement(By.Id("select2-postform-expiration-container")));
        SelectElement PasteEposure => new SelectElement(driver.FindElement(By.Id("select2-postform-status-container")));
        IWebElement PasteTitle => driver.FindElement(By.Id("postform-name"));
        IWebElement CreatePasteButton => driver.FindElement(By.ClassName("header__btn"));
        IWebElement PrivacyCheckButton => driver.FindElement(By.ClassName("css-47sehv"));

        public void Navigate()
        {
            driver.Navigate(url);
        }
        public void CheckAndHandlePrivacy()
        {
            wait.Until(By.ClassName("css-47sehv"));
            PrivacyCheckButton.Click();

        }
        public void CreateNewPaste()
        {
            CreatePasteButton.Click();
        }
        public void EnterCode(string text)
        {
            CodeForm.EnterText(text);
        }

    }
}
