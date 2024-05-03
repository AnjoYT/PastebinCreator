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
        public IWebElement CodeFormWithHiglight => this.driver.FindElement(By.CssSelector(".CodeMirror textarea"));
        public IWebElement CodeFormLocator => this.driver.FindElement(By.CssSelector(".CodeMirror textarea"));
        public IWebElement PasteExpirationLocator => this.driver.FindElement(By.Id("select2-postform-expiration-container"));
        public IWebElement PasteTitle => this.driver.FindElement(By.Id("postform-name"));
        public IWebElement CreateNewPasteButton => this.driver.FindElement(By.ClassName("header__btn"));
        public IWebElement PrivacyCheckButton => this.driver.FindElement(PrivacyButtonSelector);
        public IWebElement SubmitNewPasteButton => this.driver.FindElement(By.CssSelector("[class ='btn -big']"));
        public IWebElement SyntaxHighlight => this.driver.FindElement(By.Id("select2-postform-format-container"));
        public IWebElement SyntaxHighlightCheckbox => this.driver.FindElement(By.ClassName("toggle__control"));
        public By DropDownItems => By.CssSelector("li[class *='select2-results__option']");
        public By PrivacyButtonSelector => By.CssSelector("[class = ' css-47sehv']");
    }
}
