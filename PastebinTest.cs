using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PastebinCreator.Pages;

namespace PastebinCreator
{
    public class PastebinTest : IDisposable
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public PastebinTest()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Window.Maximize();
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void Dispose()
        {
            this.Driver.Dispose();
        }

        [Fact]
        public void CreateNewPaste()
        {
            MainPage mainPage = new MainPage(this.Driver, this.Wait);
            mainPage.Navigate();
            mainPage.CheckAndHandlePrivacy();
            mainPage.CreateNewPaste();
            mainPage.EnterCode("Hello from WebDriver");
            mainPage.PickExpirationDate("10 Minutes");
            mainPage.AddTitle("helloweb");
            mainPage.SubmitNewPaste();
        }

        [Fact]
        public void BashPasteTest()
        {
            MainPage mainPage = new MainPage(Driver, Wait);
            mainPage.Navigate();
            mainPage.CheckAndHandlePrivacy();
            mainPage.CreateNewPaste();
            mainPage.EnterCode("git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\ngit push origin master --force");
            mainPage.SetSyntax("Bash");
            mainPage.PickExpirationDate("10 Minutes");
            mainPage.AddTitle("how to gain dominance among developers");
            mainPage.SubmitNewPaste();
            PostPage postPage = new PostPage(Driver, Wait);
            postPage.Validate().ValidatetTitle("how to gain dominance among developers");
            postPage.Validate().ValidateSyntax("Bash");
            postPage.Validate().ValidateCode("git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\ngit push origin master --force");
        }
    }
}