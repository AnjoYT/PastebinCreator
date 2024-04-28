using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PastebinCreator.Pages;

namespace PastebinCreator
{
    public class PastebinTest : IDisposable
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public PastebinTest()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        [Fact]
        public void CreateNewPaste()
        {
            MainPage mainPage = new MainPage(driver, wait);
            mainPage.Navigate();
            mainPage.CheckAndHandlePrivacy();
            mainPage.CreateNewPaste();
            Dispose();
        }
    }
}