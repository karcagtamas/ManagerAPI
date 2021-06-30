namespace EventManager.Client.Models.Interfaces
{
    /// <summary>
    /// List state
    /// </summary>
    public interface IListState
    {
        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="index">Index</param>
        /// <typeparam name="T">Value type</typeparam>
        public void Add<T>(T value, int index);

        /// <summary>
        /// Get element by index
        /// </summary>
        /// <param name="index">Index</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value</returns>
        public T Get<T>(int index);

        /// <summary>
        /// Try add element
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="index">Index</param>
        /// <typeparam name="T">Value type</typeparam>
        public void TryAdd<T>(T value, int index);

        /// <summary>
        /// Try get element by index
        /// </summary>
        /// <param name="index">Index</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value</returns>
        public T TryGet<T>(int index);

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