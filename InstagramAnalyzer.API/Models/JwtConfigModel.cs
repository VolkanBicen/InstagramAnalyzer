namespace InstagramAnalyzer.API.Models
{
    public class JwtConfigModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}
