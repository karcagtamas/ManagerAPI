using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IGenderService" />
    public class GenderService : HttpCall<int>, IGenderService
    {
        /// <summary>
        /// Init Gender Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public GenderService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/gender", "Gender")
        {
        }
    }
}