using System;

namespace EventManager.Client.Models
{
    /// <summary>
    /// Modal result
    /// </summary>
    public class ModalResult
    {
        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Data type
        /// </summary>
        public Type DataType { get; }

        /// <summary>
        /// Is cancelled
        /// </summary>
        public bool Cancelled { get; }

        /// <summary>
        /// Moda type
        /// </summary>
        public Type ModalType { get; set; }

        /// <summary>
        /// Init modal result
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="resultType">Result typr</param>
        /// <param name="cancelled">Cancell</param>
        /// <param name="modalType">Modal type</param>
        protected ModalResult(object data, Type resultType, bool cancelled, Type modalType)
        {
            this.Data = data;
            this.DataType = resultType;
            this.Cancelled = cancelled;
            this.ModalType = modalType;
        }

        /// <summary>
        /// Ok result
        /// </summary>
        /// <param name="result">Result</param>
        /// <typeparam name="T">Result type</typeparam>
        /// <returns>Modal result</returns>
        public static ModalResult Ok<T>(T result)
        {
            return Ok(result, default);
        }

        /// <summary>
        /// Ok result
        /// </summary>
        /// <param name="result">Result</param>
        /// <param name="modalType">Modal type</param>
        /// <typeparam name="T">Result type</typeparam>
        /// <returns>Modal result</returns>
        public static ModalResult Ok<T>(T result, Type modalType)
        {
            return new ModalResult(result, typeof(T), false, modalType);
        }

        /// <summary>
        /// Cancel result
        /// </summary>
        /// <returns>Modal result</returns>
        public static ModalResult Cancel()
        {
            return Cancel(default);
        }

        /// <summary>
        /// Cancel result
        /// </summary>
        /// <param name="modalType">Modal type</param>
        /// <returns>Modal result</returns>
        public static ModalResult Cancel(Type modalType)
        {
            return new ModalResult(default, typeof(object), true, modalType);
        }
    }
}