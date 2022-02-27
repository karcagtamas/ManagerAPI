using AutoMapper;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using StatusLibrary.Services.Services.Interfaces;

namespace StatusLibrary.Services.Services;

/// <inheritdoc />
public class EpisodeService : NotificationRepository<Episode, int, StatusLibraryNotificationType>, IEpisodeService
{
    // Injects
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Injector constructor
    /// </summary>
    /// <param name="context">Database context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="loggerService">Logger Service</param>
    /// <param name="notificationService">Notification Service</param>
    public EpisodeService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Episode", new NotificationArguments
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
        var user = this.Utils.GetCurrentUser<User, string>();

        var episode = this._databaseContext.Episodes.FirstOrDefault(x => x.Id == id);
        if (episode != null)
        {
            var connection = episode.ConnectedUsers.FirstOrDefault(x => x.User.Id == user.Id);
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
                        EpisodeId = id,
                        Seen = true,
                        SeenOn = DateTime.Now
                    };
                    this._databaseContext.UserEpisodeSwitch.Add(userEpisode);
                }
            }

            this._databaseContext.SaveChanges();

            this.NotificationService.AddStatusLibraryNotificationByType(
                StatusLibraryNotificationType.EpisodeSeenStatusUpdated, user, episode.Season.Series.Title,
                episode.Season.Number.ToString(), episode.Number.ToString(), seen ? "Seen" : "Unseen");
        }
    }

    /// <inheritdoc />
    public void AddIncremented(int seasonId, int count)
    {
        var episodes = new List<Episode>();
        var last = this.GetList(x => x.Season.Id == seasonId).OrderBy(x => x.Number).LastOrDefault();
        int number = last?.Number + 1 ?? 1;

        for (int i = 0; i < count; i++)
        {
            var episode = new Episode
            {
                Number = number,
                SeasonId = seasonId,
                Title = "[Episode Title]"
            };

            episodes.Add(episode);

            number += 1;
        }
        this.CreateRange(episodes);
        Persist();
    }

    /// <inheritdoc />
    public void DeleteDecremented(int episodeId)
    {
        var season = this.Get(episodeId);
        int seasonId = season.Season.Id;
        int number = season.Number;

        this.DeleteById(episodeId);

        var episodes = this.GetList(x => x.Season.Id == seasonId).OrderBy(x => x.Number).Select(x =>
        {
            if (x.Number > number)
            {
                x.Number--;
            }

            return x;
        }).ToList();

        this.UpdateRange(episodes);
        Persist();
    }

    /// <inheritdoc />
    public MyEpisodeDto GetMy(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var episode = this.GetMapped<MyEpisodeDto>(id);
        var myEpisode = user.MyEpisodes.FirstOrDefault(x => x.Episode.Id == episode.Id);
        episode.IsMine = myEpisode != null;
        episode.IsSeen = myEpisode?.Seen ?? false;
        episode.SeenOn = myEpisode?.SeenOn;

        return episode;
    }

    /// <inheritdoc />
    public void UpdateImage(int id, EpisodeImageModel model)
    {
        UpdateByModel(id, model);
        Persist();
    }
}
