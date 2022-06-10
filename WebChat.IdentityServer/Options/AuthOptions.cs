namespace WebChat.IdentityServer.Options
{
    public class AuthOptions
    {
        public const string Authorization = "Authorization";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int MinuteExpires { get; set; }
    }
}