using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class SeriesCommentService : HttpCall<SeriesCommentListDto, SeriesCommentDto, SeriesCommentModel>, ISeriesCommentService
    {
        /// <summary>
        /// Init Series Comment Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public SeriesCommentService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/series-comment", "Series Comment")
        {
        }

        /// <inheritdoc />
        public async Task<List<SeriesCommentListDto>> GetList(int movieÍd)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(movieÍd, -1);

            var settings = new HttpSettings($"{this.Url}/series", null, pathParams);

            return await this.Http.Get<List<SeriesCommentListDto>>(settings);
        }
    }
}