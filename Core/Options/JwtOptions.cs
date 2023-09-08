namespace Core.Options
{
    public class JwtOptions
    {
        public const string JwtAuthOptions = "JwtAuthOptions";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
