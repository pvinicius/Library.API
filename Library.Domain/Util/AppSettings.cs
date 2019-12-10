namespace Library.Domain.Util
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHour { get; set; }
        public string Issuer { get; set; }
        public string ValidOn { get; set; }
    }
}
