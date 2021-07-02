using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class NewsService : HttpCall<NewsListDto, NewsDto, PostModel>, INewsService
    {
        /// <summary>
        /// Init News Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public NewsService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/news", "News")
        {
        }
    }
}