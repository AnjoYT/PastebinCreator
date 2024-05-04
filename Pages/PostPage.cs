using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PastebinCreator.Pages
{
    public class PostPage
    {
        private readonly string url = "https://pastebin.com/sJEDHwvS";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public PostPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public PostPageMap Map => new PostPageMap(this.driver);
        public ValidatePostPage Validate() => new ValidatePostPage(this.driver);

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        public void CheckAndHandlePrivacy()
        {
            this.Map.PrivacyButtonSelector.HandlePrivacy(this.Map.PrivacyCheckButton, this.wait);
        }
    }
}
