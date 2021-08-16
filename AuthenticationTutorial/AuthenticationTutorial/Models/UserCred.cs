namespace AuthenticationTutorial.Models
{
    public class UserCred
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RefreshCred
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}