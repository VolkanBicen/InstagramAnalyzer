using InstagramAnalyzer.Web.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InstagramAnalyzer.Web.Helpers
{
    public class InstagramLoginHelper
    {
    
        public LoginResultModel GetCookies(LoginModel model)
        {
            var result = new LoginResultModel();
            try
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless=new");

                IWebDriver driver = new ChromeDriver(options);

                // Instagram giriş sayfasını aç
                driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");

                // Kullanıcı adı ve şifreyi doldur
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(ExpectedConditions.ElementExists(By.Name("username")));
                IWebElement usernameInput = driver.FindElement(By.Name("username"));
                usernameInput.SendKeys(model.Username);

                wait.Until(ExpectedConditions.ElementExists(By.Name("password")));
                IWebElement passwordInput = driver.FindElement(By.Name("password"));
                passwordInput.SendKeys(model.Password);

                // Giriş yap butonuna tıkla
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[type='submit']")));
                IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
                loginButton.Click();

                wait.Until(d => d.Url != "https://www.instagram.com/accounts/login/");

                // Tarayıcıyı kapat
                var cookies = driver.Manage().Cookies.AllCookies;
             
                driver.Quit();
                driver.Dispose();

                result.IsLogin = true;
                result.Cookie = cookies;
                return result;
            }
            catch (Exception ex)
            {
                result.IsLogin = false;
                result.FailLoginMessage = ex.Message;
                result.Cookie = null;
                return result;
            }

        }
    }
}


