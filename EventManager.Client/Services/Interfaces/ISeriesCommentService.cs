using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Series Comment Service
    /// </summary>
    public interface ISeriesCommentService : IHttpCall<SeriesCommentListDto, SeriesCommentDto, SeriesCommentModel>
    {
        /// <summary>
        /// Get comments
        /// </summary>
        /// <param name="seriesId">Series Id</param>
        /// <returns>List of comments</returns>
        Task<List<SeriesCommentListDto>> GetList(int seriesId);
    }
}