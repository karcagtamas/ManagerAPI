using System.Collections.Generic;

namespace EventManager.Client.Models
{
    /// <summary>
    /// Modal parameters
    /// </summary>
    public class ModalParameters
    {
        private readonly Dictionary<string, object> _parameters;

        /// <summary>
        /// Init parameters
        /// </summary>
        public ModalParameters()
        {
            this._parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Value</param>
        public void Add(string parameterName, object value)
        {
            this._parameters[parameterName] = value;
        }

        /// <summary>
        /// Get parameter value
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value</returns>
        public T Get<T>(string parameterName)
        {
            if (!this._parameters.ContainsKey(parameterName))
            {
                throw new KeyNotFoundException("Not exist.");
            }
            return (T)this._parameters[parameterName];
        }

        /// <summary>
        /// Try get parameter value
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value</returns>
        public T TryGet<T>(string parameterName)
        {
            if (this._parameters.ContainsKey(parameterName))
            {
                return (T)this._parameters[parameterName];
            }
            return default;
        }
    }
}