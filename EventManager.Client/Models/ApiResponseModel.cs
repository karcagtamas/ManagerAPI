namespace EventManager.Client.Models
{
    /// <summary>
    /// API response
    /// </summary>
    /// <typeparam name="T">Content type</typeparam>
    public class ApiResponseModel<T>
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Is success
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public T Content { get; set; }
    }
}