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
public class SeriesService : NotificationRepository<Series, int, StatusLibraryNotificationType>, ISeriesService
{
    // Injects
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Injector Constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="loggerService">Logger Service</param>
    /// <param name="notificationService"></param>
    public SeriesService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Series",
        new NotificationArguments
        {
            DeleteArguments = new List<string> { "Title" },
            UpdateArguments = new List<string> { "Title" },
            CreateArguments = new List<string> { "Title" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public void AddSeriesToMySeries(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserSeriesSwitch.FirstOrDefault(x => x.UserId == user.Id && x.SeriesId == id);

        if (mapping == null)
        {
            mapping = new UserSeries { SeriesId = id, UserId = user.Id, AddedOn = DateTime.Now, IsAdded = true };
            this._databaseContext.UserSeriesSwitch.Add(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MySeriesListUpdated,
                user);
        }
        else
        {
            mapping.AddedOn = DateTime.Now;
            mapping.IsAdded = true;
            this._databaseContext.UserSeriesSwitch.Update(mapping);
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MySeriesListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public MySeriesDto GetMy(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var series = this.GetMapped<MySeriesDto>(id);
        var mySeries = user.MySeries.FirstOrDefault(x => x.Series.Id == series.Id);
        series.IsMine = mySeries?.IsAdded ?? false;
        series.AddedOn = mySeries?.AddedOn;
        series.Rate = mySeries?.Rate ?? 0;


        foreach (var season in series.Seasons)
        {
            foreach (var episode in season.Episodes)
            {
                var myEpisode = user.MyEpisodes.FirstOrDefault(x => x.Episode.Id == episode.Id);
                episode.Seen = myEpisode != null && myEpisode.Seen;
            }

            season.IsSeen = season.Episodes.Select(x => x.Seen).All(x => x);
        }

        series.IsSeen = series.Seasons.SelectMany(x => x.Episodes.Select(y => y.Seen)).All(x => x);

        return series;
    }

    /// <inheritdoc />
    public List<MySeriesListDto> GetMyList()
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = user.MySeries.ToList();

        return this.Mapper.Map<List<MySeriesListDto>>(list).OrderBy(x => x.Title).ToList();
    }

    /// <inheritdoc />
    public List<MySeriesSelectorListDto> GetMySelectorList(bool onlyMine)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.GetAllMapped<MySeriesSelectorListDto>().OrderBy(x => x.Title).ToList();
        foreach (var t in list)
        {
            var mySeries = user.MySeries.FirstOrDefault(x => x.Series.Id == t.Id);
            t.IsMine = mySeries != null;
        }

        if (onlyMine)
        {
            list = list.Where(x => x.IsMine).ToList();
        }

        return list;
    }

    /// <inheritdoc />
    public void UpdateImage(int id, SeriesImageModel model)
    {
        var series = this._databaseContext.Series.Find(id);

        if (series == null)
        {
            return;
        }

        this.Mapper.Map(model, series);

        this.Update(series);
        Persist();
    }

    /// <inheritdoc />
    public void UpdateCategories(int id, SeriesCategoryUpdateModel model)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var series = this._databaseContext.Series.Find(id);

        if (series == null)
        {
            return;
        }

        var currentMappings = series.Categories;

        foreach (var mapping in currentMappings)
        {
            if (!model.Ids.Contains(mapping.Category.Id))
            {
                this._databaseContext.SeriesSeriesCategoriesSwitch.Remove(mapping);
            }
        }

        var addList = model.Ids.Where(x =>
            !currentMappings.Select(y => y.Category.Id).Contains(x)).ToList();

        foreach (int modelId in addList)
        {
            this._databaseContext.SeriesSeriesCategoriesSwitch.Add(new SeriesSeriesCategory
            { CategoryId = modelId, SeriesId = series.Id });
        }

        this._databaseContext.SaveChanges();
        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.UpdateSeries, user);
    }

    /// <inheritdoc />
    public void UpdateRate(int id, SeriesRateModel model)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var map = user.MySeries.FirstOrDefault(x => x.Series.Id == id);

        if (map != null)
        {
            map.Rate = model.Rate;
            this._databaseContext.UserSeriesSwitch.Update(map);
            this._databaseContext.SaveChanges();
        }
        else
        {
            map = new UserSeries
            { UserId = user.Id, SeriesId = id, IsAdded = false, Rate = model.Rate };
            this._databaseContext.UserSeriesSwitch.Add(map);
            this._databaseContext.SaveChanges();
        }
    }

    /// <inheritdoc />
    public void RemoveSeriesFromMySeries(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserSeriesSwitch.FirstOrDefault(x => x.UserId == user.Id && x.SeriesId == id);

        if (mapping != null)
        {
            mapping.IsAdded = false;
            mapping.AddedOn = null;
            this._databaseContext.UserSeriesSwitch.Update(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MySeriesListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public void UpdateMySeries(List<int> ids)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var currentMappings = this._databaseContext.UserSeriesSwitch.Where(x => x.UserId == user.Id).ToList();
        foreach (var i in currentMappings)
        {
            if (ids.FindIndex(x => x == i.SeriesId) == -1)
            {
                i.IsAdded = false;
                i.AddedOn = null;
                this._databaseContext.UserSeriesSwitch.Update(i);
            }
            else
            {
                i.IsAdded = true;
                i.AddedOn = DateTime.Now;
                this._databaseContext.UserSeriesSwitch.Update(i);
            }
        }

        foreach (int i in ids)
        {
            if (currentMappings.FirstOrDefault(x => x.SeriesId == i) == null)
            {
                var map = new UserSeries { SeriesId = i, UserId = user.Id, AddedOn = DateTime.Now, IsAdded = true };
                this._databaseContext.UserSeriesSwitch.Add(map);
            }
        }

        this._databaseContext.SaveChanges();
        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MySeriesListUpdated,
            user);
    }

    /// <inheritdoc />
    public void UpdateSeenStatus(int id, bool seen)
    {
        var user = this.Utils.GetCurrentUser<User, string>();
        var series = this._databaseContext.Series.Find(id);

        var episodes = this._databaseContext.Episodes.Where(x => x.Season.Series.Id == id).ToList();
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

        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.SeriesSeenStatusUpdated,
            user, series?.Title ?? "", seen ? "Seen" : "Unseen");
    }
}
