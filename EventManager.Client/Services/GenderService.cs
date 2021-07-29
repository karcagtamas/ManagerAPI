using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class GenderService : HttpCall<GenderListDto, GenderDto, GenderModel>, IGenderService
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