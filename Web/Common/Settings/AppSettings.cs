namespace Web.Common.Settings
{
    public class AppSettings
    {
        public MovieApiSettings MovieApi { get; set; }
    }

    public class MovieApiSettings
    {
        public string Host { get; set; }
        public string ApiKey { get; set; }
    }
}
