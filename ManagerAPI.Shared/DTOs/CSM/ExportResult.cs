namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Export Result
    /// </summary>
    public class ExportResult
    {
        /// <summary>
        /// Content
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; }
    }
}
