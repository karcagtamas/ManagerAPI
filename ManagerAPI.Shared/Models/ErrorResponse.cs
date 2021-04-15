using System;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Error response model
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Inner Error
        /// </summary>
        public ErrorResponse Inner { get; set; }

        /// <summary>
        /// Stack Trace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Error response from Exception
        /// </summary>
        /// <param name="e">Exception</param>
        public ErrorResponse(Exception e)
        {
            this.Message = e.Message;
            if (e.InnerException != null)
            {
                this.Inner = new ErrorResponse(e.InnerException);
            }

            if (e.StackTrace != null)
            {
                this.StackTrace = e.StackTrace;
            }
        }
    }
}