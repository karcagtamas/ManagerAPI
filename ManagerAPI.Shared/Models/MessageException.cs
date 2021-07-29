using System;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Own Generated Message Exception
    /// </summary>
    public class MessageException : Exception
    {
        /// <summary>
        /// Empty init
        /// </summary>
        public MessageException()
        {
        }

        /// <summary>
        /// Exception with message
        /// </summary>
        /// <param name="msg">Exception message</param>
        public MessageException(string msg) : base(msg)
        {
        }

        /// <summary>
        /// Exception with message and inner Exception
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="innerException">Exception</param>
        public MessageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}