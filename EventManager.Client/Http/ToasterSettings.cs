namespace EventManager.Client.Http
{
    /// <summary>
    /// Toaster settings
    /// </summary>
    public class ToasterSettings
    {
        /// <summary>
        /// Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Is needed
        /// </summary>
        public bool IsNeeded { get; set; }

        /// <summary>
        /// Init Toaster settings
        /// </summary>
        public ToasterSettings()
        {
            this.IsNeeded = false;
        }

        /// <summary>
        /// Init Toaster settings with caption
        /// </summary>
        public ToasterSettings(string caption)
        {
            this.Caption = caption;
            this.IsNeeded = true;
        }
    }
}