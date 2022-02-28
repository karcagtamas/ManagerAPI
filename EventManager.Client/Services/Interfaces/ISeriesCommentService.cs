using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Series Comment Service
    /// </summary>
    public interface ISeriesCommentService : IHttpCall<int>
    {
        /// <summary>
        /// Get comments
        /// </summary>
        /// <param name="seriesId">Series Id</param>
        /// <returns>List of comments</returns>
        Task<List<SeriesCommentListDto>> GetList(int seriesId);
    }
}