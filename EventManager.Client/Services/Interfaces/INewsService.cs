using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// News Service
    /// </summary>
    public interface INewsService : IHttpCall<int>
    {
    }
}