using OpenQA.Selenium;

namespace PastebinCreator.Pages
{
    public class PostPageMap
    {
        private readonly IWebDriver driver;
        public PostPageMap(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement ExpirationTime => this.driver.FindElement(By.ClassName("expire"));
        public IWebElement Title => this.driver.FindElement(By.CssSelector(".info-top h1"));
        public IWebElement Syntax => this.driver.FindElement(By.CssSelector("[class = 'btn -small h_800']"));
        public IWebElement Code => this.driver.FindElement(By.CssSelector("ol.bash"));
        public IWebElement PrivacyCheckButton => this.driver.FindElement(PrivacyButtonSelector);
        public By PrivacyButtonSelector => By.CssSelector("[class = ' css-47sehv']");
    }
}
