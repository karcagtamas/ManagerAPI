using System.Threading.Tasks;

namespace EventManager.Client.Http
{
    /// <summary>
    /// HTTP Service
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// GET request
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <typeparam name="T">Type of the result</typeparam>
        /// <returns>Response as T type</returns>
        Task<T> Get<T>(HttpSettings settings);

        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <returns>String response</returns>
        Task<string> GetString(HttpSettings settings);

        /// <summary>
        /// Get number
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <returns>Number response</returns>
        Task<int?> GetInt(HttpSettings settings);

        /// <summary>
        /// DELETE request
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <returns>The request was success or not</returns>
        Task<bool> Delete(HttpSettings settings);

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="body">Body of put request</param>
        /// <typeparam name="T">Type of the body</typeparam>
        /// <returns>The request was success or not</returns>
        Task<bool> Update<T>(HttpSettings settings, HttpBody<T> body);

        /// <summary>
        /// POST request
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="body">Body of post request</param>
        /// <typeparam name="T">Type of the body</typeparam>
        /// <returns>The request was success or not</returns>
        Task<bool> Create<T>(HttpSettings settings, HttpBody<T> body);

        /// <summary>
        /// POST request where we want string response
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="body">Body of post request</param>
        /// <typeparam name="T">Type of the body</typeparam>
        /// <returns>Response string value</returns>
        Task<string> CreateString<T>(HttpSettings settings, HttpBody<T> body);

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="body">Body of put request</param>
        /// <typeparam name="T">Type of the body</typeparam>
        /// <typeparam name="V">Type of the result</typeparam>
        /// <returns>Result of the request</returns>
        Task<T> UpdateWithResult<T, V>(HttpSettings settings, HttpBody<V> body);

        /// <summary>
        /// POST request where we want int response
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="body">Body of post request</param>
        /// <typeparam name="T">Type of the body</typeparam>
        /// <returns>Response int value</returns>
        Task<int> CreateInt<T>(HttpSettings settings, HttpBody<T> body);

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <returns>The request was success or not</returns>
        Task<bool> Download(HttpSettings settings);

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="settings">HTTP settings</param>
        /// <param name="model">Source model</param>
        /// <typeparam name="T">Type of the model</typeparam>
        /// <returns>The request was success or not</returns>
        Task<bool> Download<T>(HttpSettings settings, T model);
    }
}