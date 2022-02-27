using KarcagS.Common.Tools.Entities;
using KarcagS.Common.Tools.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Repositories;

/// <summary>
/// Notification Repository
/// </summary>
/// <typeparam name="T">Entity</typeparam>
/// <typeparam name="TKey">Key</typeparam>
public interface INotificationRepository<T, TKey> : IMapperRepository<T, TKey> where T : class, IEntity<TKey>
{
}
