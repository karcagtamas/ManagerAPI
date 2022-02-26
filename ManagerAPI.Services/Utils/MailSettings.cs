namespace ManagerAPI.Services.Utils
{
    /// <summary>
    /// Mail Settings
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Mail address
        /// </summary>
        public string Mail { get; set; } = string.Empty;

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;


        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
    }
}