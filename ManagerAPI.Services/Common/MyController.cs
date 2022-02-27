using KarcagS.Common.Tools.Entities;
using ManagerAPI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Services.Common;

/// <summary>
/// My Controller
/// </summary>
/// <typeparam name="TEntity">Type of Entity</typeparam>
/// <typeparam name="TKey">Entity Key type</typeparam>
/// <typeparam name="TModel">Type of Model object</typeparam>
/// <typeparam name="TList">Type of List object</typeparam>
/// <typeparam name="TSimple">Type of Simple data object</typeparam>
public class MyController<TEntity, TKey, TModel, TList, TSimple> : ControllerBase, IController<TEntity, TKey, TModel> where TEntity : class, IEntity<TKey>
{
    private readonly INotificationRepository<TEntity, TKey> _service;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="service">Repository service</param>
    public MyController(INotificationRepository<TEntity, TKey> service)
    {
        this._service = service;
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="model">Object model</param>
    /// <returns>Ok state</returns>
    [HttpPost]
    public virtual IActionResult Create([FromBody] TModel model)
    {
        this._service.CreateFromModel(model);
        return this.Ok();
    }

    /// <summary>
    /// Delete by Id
    /// </summary>
    /// <param name="id">Id of object</param>
    /// <returns>Ok state</returns>
    [HttpDelete("{id}")]
    public virtual IActionResult Delete(TKey id)
    {
        this._service.DeleteById(id);
        return this.Ok();
    }

    /// <summary>
    /// Get by Id
    /// </summary>
    /// <param name="id">Id of object</param>
    /// <returns>Element in ok state</returns>
    [HttpGet("{id}")]
    public IActionResult Get(TKey id)
    {
        return this.Ok(this._service.GetMapped<TSimple>(id));
    }

    /// <summary>
    /// Get all element
    /// </summary>
    /// <param name="orderBy">Order by</param>
    /// <param name="direction">Order direction</param>
    /// <returns>List of elements in ok state</returns>
    [HttpGet]
    public IActionResult GetAll([FromQuery] string orderBy, [FromQuery] string direction)
    {
        if (string.IsNullOrEmpty(orderBy) || string.IsNullOrEmpty(direction))
        {
            return this.Ok(this._service.GetAllMapped<TList>());
        }

        return this.Ok(this._service.GetAllMappedAsOrdered<TList>(orderBy, direction));
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="id">Id of object</param>
    /// <param name="model">Model of object</param>
    /// <returns>Ok state</returns>
    [HttpPut("{id}")]
    public virtual IActionResult Update(TKey id, TModel model)
    {
        this._service.UpdateByModel(id, model);
        return this.Ok();
    }
}
