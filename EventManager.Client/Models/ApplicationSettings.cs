namespace EventManager.Client.Models
{
    /// <summary>
    /// Application Settings
    /// </summary>
    public static class ApplicationSettings
    {
        /// <summary>
        /// Base url
        /// </summary>
        public static string BaseUrl { get; set; } = "http://192.168.1.80:7222";

        /// <summary>
        /// Base API url
        /// </summary>
        public static string BaseApiUrl { get; set; } = "http://192.168.1.80:7222/api";
    }
}