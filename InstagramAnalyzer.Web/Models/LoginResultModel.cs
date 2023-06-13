namespace InstagramAnalyzer.Web.Models
{
    public class LoginResultModel
    {
        public bool IsLogin { get; set; }
        public string FailLoginMessage { get; set; }
        public IReadOnlyCollection<OpenQA.Selenium.Cookie>? Cookie { get; set; }
    }
}
