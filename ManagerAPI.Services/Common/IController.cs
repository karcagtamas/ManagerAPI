using KarcagS.Common.Tools.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Services.Common;

/// <summary>
/// Controller interface
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TKey">Entity key type</typeparam>
/// <typeparam name="TModel">Model type</typeparam>
public interface IController<TEntity, TKey, TModel> where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// GET call
    /// </summary>
    /// <param name="id">Path param</param>
    /// <returns>Action result</returns>
    IActionResult Get(TKey id);

    /// <summary>
    /// GET call
    /// </summary>
    /// <param name="orderBy">Ordering</param>
    /// <param name="direction">Direction</param>
    /// <returns>Action result</returns>
    IActionResult GetAll([FromQuery] string orderBy, [FromQuery] string direction);

    /// <summary>
    /// DELETE call
    /// </summary>
    /// <param name="id">Path param</param>
    /// <returns>Action result</returns>
    IActionResult Delete(TKey id);

    /// <summary>
    /// PUT call
    /// </summary>
    /// <param name="id">Path param</param>
    /// <param name="model">Body</param>
    /// <returns>Action result</returns>
    IActionResult Update(TKey id, TModel model);

    /// <summary>
    /// POST call
    /// </summary>
    /// <param name="model">Body</param>
    /// <returns>Action result</returns>
    IActionResult Create(TModel model);
}
