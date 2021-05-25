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
        public string Mail { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
    }
}