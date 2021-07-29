using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// News Service
    /// </summary>
    public interface INewsService : IHttpCall<NewsListDto, NewsDto, PostModel>
    {
    }
}