using System.ComponentModel.DataAnnotations;

namespace InstagramAnalyzer.API.Data
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
