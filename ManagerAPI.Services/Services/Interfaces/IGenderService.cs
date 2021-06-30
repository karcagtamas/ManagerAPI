using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common.Repository;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Gender Service
    /// </summary>
    public interface IGenderService : IRepository<Gender>
    {
    }
}