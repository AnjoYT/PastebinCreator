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
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public void Dispose()
        {
            //Driver.Dispose();
        }

        [Fact]
        public void CreateNewPaste()
        {
            MainPage mainPage = new MainPage(Driver, Wait);
            mainPage.Navigate();
            mainPage.CheckAndHandlePrivacy();
            mainPage.CreateNewPaste();
            mainPage.EnterCode("Hello from WebDriver");
            mainPage.PickExpirationDate("10 Minutes");
            mainPage.AddTitle("helloweb");
            mainPage.SubmitNewPaste();
        }

        [Fact]
        public void CreateBashPaste()
        {
            MainPage mainPage = new MainPage(Driver, Wait);
            mainPage.Navigate();
            mainPage.CheckAndHandlePrivacy();
            mainPage.CreateNewPaste();
            mainPage.EnableSyntaxHighlight();
            mainPage.EnterCodeWithHighlight("git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\ngit push origin master --force\n");
            mainPage.SetSyntax("Bash");
            mainPage.PickExpirationDate("10 Minutes");
            mainPage.AddTitle("how to gain dominance among developers");
            mainPage.SubmitNewPaste();
        }
    }
}