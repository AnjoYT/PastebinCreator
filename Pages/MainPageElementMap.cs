using OpenQA.Selenium;

namespace PastebinCreator.Pages
{
    public class MainPageElementMap
    {
        private readonly IWebDriver driver;
        public MainPageElementMap(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement CodeFormLocator => this.driver.FindElement(By.Id("postform-text"));
        public IWebElement PasteExpirationLocator => this.driver.FindElement(By.Id("select2-postform-expiration-container"));
        public IWebElement PasteTitle => this.driver.FindElement(By.Id("postform-name"));
        public IWebElement CreatePasteButton => this.driver.FindElement(By.ClassName("header__btn"));
        public IWebElement PrivacyCheckButton => this.driver.FindElement(By.ClassName("css-47sehv"));
    }
}
