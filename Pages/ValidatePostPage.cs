using OpenQA.Selenium;

namespace PastebinCreator.Pages
{
    public class ValidatePostPage
    {
        private readonly IWebDriver driver;
        public ValidatePostPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected PostPageMap Map => new PostPageMap(driver);

        public void ValidatetTitle(string expected)
        {
            Assert.True(this.Map.Title.Text.Contains(expected), "Post title doesnt match with expected");
        }
        public void ValidateExpiration(string expected)
        {
            Assert.True(this.Map.ExpirationTime.Text.Contains(expected), "Post expiration date doesnt match with expected");
        }
        public void ValidateSyntax(string expected)
        {
            Assert.True(this.Map.Syntax.Text.Contains(expected), "Post syntax doesnt match with expected");
        }

        public void ValidateCode(string expected)
        {
            Assert.True(expected.CompareElements(this.Map.Code), "Code doesnt match with expected");
        }

    }
}
