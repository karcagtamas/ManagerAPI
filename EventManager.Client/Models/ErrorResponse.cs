using System;

namespace EventManager.Client.Models
{

    /// <summary>
    /// Error Response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Inner error
        /// </summary>
        public ErrorResponse Inner { get; set; }

        /// <summary>
        /// Stack trace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Init Error response fordeserialization
        /// </summary>
        public ErrorResponse()
        {

        }

        /// <summary>
        /// Init Error response from Exception
        /// </summary>
        /// <param name="e">Exception</param>
        public ErrorResponse(Exception e)
        {
            this.Message = e.Message;

            // Inner exception
            if (e.InnerException != null)
            {
                this.Inner = new ErrorResponse(e.InnerException);
            }

            // Stack trace
            if (e.StackTrace != null)
            {
                this.StackTrace = e.StackTrace;
            }
        }
    }
}