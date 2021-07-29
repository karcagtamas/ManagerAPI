using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Gender Service
    /// </summary>
    public interface IGenderService : IHttpCall<GenderListDto, GenderDto, GenderModel>
    {

    }
}