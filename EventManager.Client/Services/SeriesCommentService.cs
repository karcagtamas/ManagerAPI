using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class SeriesCommentService : HttpCall<int>, ISeriesCommentService
    {
        /// <summary>
        /// Init Series Comment Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public SeriesCommentService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/series-comment", "Series Comment")
        {
        }

        /// <inheritdoc />
        public async Task<List<SeriesCommentListDto>> GetList(int seriesId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(seriesId);

            var settings = new HttpSettings(Http.BuildUrl(Url, "series")).AddPathParams(pathParams);

            return await this.Http.Get<List<SeriesCommentListDto>>(settings).ExecuteWithResult() ?? new();
        }
    }
}