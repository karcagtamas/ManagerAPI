using AutoMapper;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Services.Services.Interfaces;
using StatusLibrary.Services.Services.Interfaces;

namespace StatusLibrary.Services.Services;

/// <inheritdoc />
public class SeasonService : Repository<Season, StatusLibraryNotificationType>, ISeasonService
{
    // Injects
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Injector constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="loggerService">Logger Service</param>
    /// <param name="notificationService">Notification Service</param>
    public SeasonService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, notificationService, mapper, "Season",
        new NotificationArguments
        {
            DeleteArguments = new List<string> { "Number" },
            UpdateArguments = new List<string> { "Number" },
            CreateArguments = new List<string> { "Number" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public void UpdateSeenStatus(int id, bool seen)
    {
        var user = this.Utils.GetCurrentUser();
        var season = this._databaseContext.Seasons.Find(id);

        var episodes = this._databaseContext.Episodes.Where(x => x.Season.Id == id).ToList();
        foreach (var i in episodes)
        {
            var connection = i.ConnectedUsers.FirstOrDefault(x => x.User.Id == user.Id);
            if (connection != null)
            {
                connection.Seen = seen;
                connection.SeenOn = seen ? DateTime.Now : null;
                this._databaseContext.UserEpisodeSwitch.Update(connection);
            }
            else
            {
                if (seen)
                {
                    var userEpisode = new UserEpisode
                    {
                        UserId = user.Id,
                        EpisodeId = i.Id,
                        Seen = true,
                        SeenOn = DateTime.Now
                    };
                    this._databaseContext.UserEpisodeSwitch.Add(userEpisode);
                }
            }
        }

        this._databaseContext.SaveChanges();

        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("set season seen status for"), id);
        this.Notification.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.SeasonSeenStatusUpdated,
            user, season?.Series.Title ?? "", season?.Number.ToString() ?? "", seen ? "Seen" : "Unseen");
    }

    /// <inheritdoc />
    public void AddIncremented(int seriesId, int count)
    {
        var seasons = new List<Season>();
        var last = this.GetList(x => x.Series.Id == seriesId).OrderBy(x => x.Number).LastOrDefault();
        int number = last?.Number + 1 ?? 1;

        for (int i = 0; i < count; i++)
        {
            var season = new Season
            {
                Number = number,
                SeriesId = seriesId
            };

            seasons.Add(season);

            number += 1;
        }

        this.AddRange(seasons);
    }

    /// <inheritdoc />
    public void DeleteDecremented(int seasonId)
    {
        var season = this.Get(seasonId);
        int seriesId = season.Series.Id;
        int number = season.Number;

        this.Remove(seasonId);

        var seasons = this.GetList(x => x.SeriesId == seriesId).OrderBy(x => x.Number).Select(x =>
        {
            if (x.Number > number)
            {
                x.Number--;
            }

            return x;
        }).ToList();

        this.UpdateRange(seasons);
    }
}
