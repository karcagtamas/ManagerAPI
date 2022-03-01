using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Services;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IMessageService" />
    public class MessageService : HttpCall<int>, IMessageService
    {

        /// <summary>
        /// Init Message Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <returns></returns>
        public MessageService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/message", "Message")
        {
            
        }

        /// <inheritdoc />
        public async Task<List<MessageDto>> GetMessages(int friendId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(friendId, -1);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "friend")).AddPathParams(pathParams);

            return await this.Http.Get<List<MessageDto>>(settings).ExecuteWithResult() ?? new List<MessageDto>();
        }

        /// <inheritdoc />
        public async Task<bool> SendMessage(MessageModel model)
        {
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "send")).AddToaster("Message sending");

            var body = new HttpBody<MessageModel>(model);

            return await this.Http.Post(settings, body).Execute();
        }
    }
}