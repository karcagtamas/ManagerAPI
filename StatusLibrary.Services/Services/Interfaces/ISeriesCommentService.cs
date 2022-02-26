using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Series Comment Service
/// </summary>
public interface ISeriesCommentService : IRepository<SeriesComment>
{
    /// <summary>
    /// Get list of comments for the given series.
    /// </summary>
    /// <param name="seriesId">Series Id</param>
    /// <returns>List of comments</returns>
    List<SeriesCommentListDto> GetList(int seriesId);
}
