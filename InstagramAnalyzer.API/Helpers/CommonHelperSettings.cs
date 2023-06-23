namespace InstagramAnalyzer.API.Helpers
{
    public class CommonHelperSettings
    {
        static CommonHelperSettings()
        {
        }

        private CommonHelperSettings()
        {
        }

        public static CommonHelperSettings Instance { get; } = new CommonHelperSettings();

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }

        public static void Initialize()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            Instance.Issuer = root.GetSection("Jwt:Issuer").Value;
            Instance.Audience = root.GetSection("Jwt:Audience").Value;
            Instance.Key = root.GetSection("Jwt:Key").Value;


        }

    }
}
