using AutoMapper;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using MovieCorner.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieCorner.Services.Services
{
    /// <inheritdoc />
    public class EpisodeService : Repository<Episode, StatusLibraryNotificationType>, IEpisodeService
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
            utilsService, notificationService, mapper, "Episode", new NotificationArguments
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

            var episode = this._databaseContext.Episodes.FirstOrDefault(x => x.Id == id);
            if (episode != null)
            {
                var connection = episode.ConnectedUsers.FirstOrDefault(x => x.User.Id == user.Id);
                if (connection != null)
                {
                    connection.Seen = seen;
                    connection.SeenOn = seen ? (DateTime?)DateTime.Now : null;
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

                this.Logger.LogInformation(user, this.GetService(), this.GetEvent("set episode seen status for"), id);
                this.Notification.AddStatusLibraryNotificationByType(
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
            this.AddRange(episodes);
        }

        /// <inheritdoc />
        public void DeleteDecremented(int episodeId)
        {
            var season = this.Get(episodeId);
            int seasonId = season.Season.Id;
            int number = season.Number;

            this.Remove(episodeId);

            var episodes = this.GetList(x => x.Season.Id == seasonId).OrderBy(x => x.Number).Select(x =>
            {
                if (x.Number > number)
                {
                    x.Number--;
                }

                return x;
            }).ToList();

            this.UpdateRange(episodes);
        }

        /// <inheritdoc />
        public MyEpisodeDto GetMy(int id)
        {
            var user = this.Utils.GetCurrentUser();

            var episode = this.Get<MyEpisodeDto>(id);
            var myEpisode = user.MyEpisodes.FirstOrDefault(x => x.Episode.Id == episode.Id);
            episode.IsMine = myEpisode != null;
            episode.IsSeen = myEpisode?.Seen ?? false;
            episode.SeenOn = myEpisode?.SeenOn;

            this.Logger.LogInformation(user, this.GetService(), this.GetEvent("get my"), episode.Id);

            return episode;
        }

        /// <inheritdoc />
        public void UpdateImage(int id, EpisodeImageModel model)
        {
            var user = this.Utils.GetCurrentUser();

            var episode = this._databaseContext.Episodes.Find(id);

            if (episode == null)
            {
                return;
            }

            this.Mapper.Map(model, episode);

            this.Update(episode);
        }
    }
}