using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;

namespace MovieCorner.Services.Services.Interfaces
{
    public interface ISeasonService : IRepository<Season>
    {
        void UpdateSeenStatus(int id, bool seen);
        void AddIncremented(int seriesId);
        void DeleteDecremented(int seasonId);
    }
}