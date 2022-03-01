using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class NewsService : HttpCall<int>, INewsService
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