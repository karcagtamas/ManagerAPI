using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Http
{
    /// <summary>
    /// HTTP Call
    /// </summary>
    public interface IHttpCall<TList, TSimple, TModel>
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <params name="orderBy">Ordering of the list</params>
        /// <params name="direction">The ordering direction</params>
        /// <returns>List</returns>
        Task<List<TList>> GetAll(string orderBy, string direction = "asc");

        /// <summary>
        /// Get element by Id
        /// </summary>
        /// <params name="id">Id</params>
        /// <returns>Element object</returns>
        Task<TSimple> Get(int id);

        /// <summary>
        /// Create from model
        /// </summary>
        /// <params name="model">Model</params>
        /// <returns>True if it was successful</returns>
        Task<bool> Create(TModel model);

        /// <summary>
        /// Update from model by Id
        /// </summary>
        /// <params name="id">Id</params>
        /// <params name="model">Model</params>
        /// <returns>True if it was successful</returns>
        Task<bool> Update(int id, TModel model);

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <params name="id">Id</params>
        /// <returns>True if it was successful</returns>
        Task<bool> Delete(int id);
    }
}