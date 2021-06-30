namespace EventManager.Client.Models.Interfaces
{
    /// <summary>
    /// Dictionary state
    /// </summary>
    public interface IDictionaryState
    {
        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Value type</typeparam>
        public void Add<T>(string key, T value);

        /// <summary>
        /// Get element by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value</returns>
        public T Get<T>(string key);

        /// <summary>
        /// Try add element
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Value type</typeparam>
        public void TryAdd<T>(string key, T value);

        /// <summary>
        /// Try get element
        /// </summary>
        /// <param name="key">Key</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Type</returns>
        public T TryGet<T>(string key);

        /// <summary>
        /// Get count of elements
        /// </summary>
        /// <returns>Number</returns>
        public int Count();

        /// <summary>
        /// Convert state to string
        /// </summary>
        /// <returns>String</returns>
        public string ToString();
    }
}