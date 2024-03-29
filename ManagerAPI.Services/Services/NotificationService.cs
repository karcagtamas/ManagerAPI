using AutoMapper;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Domain.Enums.WM;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerAPI.Services.Services
{
    /// <inheritdoc />
    public class NotificationService : INotificationService
    {
        private readonly IUtilsService _utilsService;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Injector constructor
        /// </summary>
        /// <param name="utilsService">Utils Service</param>
        /// <param name="context">Database context</param>
        /// <param name="loggerService">Logger Service</param>
        /// <param name="mapper">Mapper</param>
        public NotificationService(IUtilsService utilsService, DatabaseContext context, IMapper mapper,
            ILoggerService loggerService)
        {
            this._utilsService = utilsService;
            this._context = context;
            this._mapper = mapper;
            this._loggerService = loggerService;
        }

        /// <inheritdoc />
        public void AddNotification(User user, int type, string val, params string[] args)
        {
            // Create notification
            var notification = new Notification
            {
                Content = this._utilsService.InjectString(val, args),
                OwnerId = user.Id,
                TypeId = type
            };

            // Save notification
            this._context.Notifications.Add(notification);
            this._context.SaveChanges();
            this._loggerService.LogInformation(user, nameof(NotificationService), "add notification", notification.Id);
        }

        /// <inheritdoc />
        public void AddSystemNotificationByType(SystemNotificationType type, User user, params string[] args)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null");
            }

            // Determine message by type
            string val = type
                switch
            {
                SystemNotificationType.Login => "Successfully logged in. Welcome.",
                SystemNotificationType.Logout => "Successfully logged out.",
                SystemNotificationType.Registration => "Successfully registered. Have fun.",
                SystemNotificationType.MessageArrived => "You have a new unread message from {0}.",
                SystemNotificationType.MyProfileUpdated => "You profile data successfully updated",
                SystemNotificationType.AddTask => "{0} task successfully added. Do not forget it.",
                SystemNotificationType.DeleteTask => "{0} task successfully deleted.",
                SystemNotificationType.UpdateTask => "{0} task successfully updated.",
                SystemNotificationType.PasswordChanged => "Password changed",
                SystemNotificationType.ProfileImageChanged => "Profile image changed",
                SystemNotificationType.UsernameChanged => "Username changed from {0} to {1}",
                SystemNotificationType.ProfileDisabled => "Profile disabled",
                SystemNotificationType.FriendRequestReceived => "Friend request received from {0}",
                SystemNotificationType.FriendRequestSent => "Friend request sent to {0}",
                SystemNotificationType.FriendRequestAccepted => "Your friend request accepted by {0}",
                SystemNotificationType.FriendRequestDeclined => "Your friend request declined by {0}",
                SystemNotificationType.YouHasANewFriend => "{0} is your friend now",
                SystemNotificationType.FriendRemoved => "{0} removed from your friend list",
                SystemNotificationType.AddNews => "News added by {0}",
                SystemNotificationType.UpdateNews => "News updated by {0}",
                SystemNotificationType.DeleteNews => "News deleted by {0}",
                SystemNotificationType.AddMessage => "Message added",
                SystemNotificationType.DeleteMessage => "Message deleted",
                SystemNotificationType.UpdateMessage => "Message updated",
                SystemNotificationType.AddGender => "Gender added with title {0}",
                SystemNotificationType.DeleteGender => "Gender deleted with title {0}",
                SystemNotificationType.UpdateGender => "Gender updated with title {0}",
                _ =>
                throw new Exception("System Notification is not implemented"),
            };

            this.AddNotification(user, (int)type, val, args);
        }

        /// <inheritdoc />
        public void AddWorkingManagerNotificationByType(WorkingManagerNotificationType type, User user,
            params string[] args)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null");
            }

            // Determine message by type
            string val = type
                switch
            {
                WorkingManagerNotificationType.AddWorkingField => "Working field created with length: {0}",
                WorkingManagerNotificationType.DeleteWorkingField => "Working field deleted on {0}",
                WorkingManagerNotificationType.UpdateWorkingField => "Working field updated on {0}",
                WorkingManagerNotificationType.AddWorkingDay => "Working day initialized on {0}",
                WorkingManagerNotificationType.DeleteWorkingDay => "Working day deleted on {0}",
                WorkingManagerNotificationType.UpdateWorkingDay => "Working day updated on {0}",
                WorkingManagerNotificationType.AddWorkingDayType => "Working day type created with title: {0}",
                WorkingManagerNotificationType.DeleteWorkingDayType => "Working day type deleted with title: {0}",
                WorkingManagerNotificationType.UpdateWorkingDayType => "Working day type updated with title: {0}",
                _ =>
                throw new Exception("Working Manager Notification is not implemented"),
            };

            this.AddNotification(user, (int)type, val, args);
        }

        /// <inheritdoc />
        public void AddStatusLibraryNotificationByType(StatusLibraryNotificationType type, User user,
            params string[] args)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null");
            }

            // Determine message by type
            string val = type
                switch
            {
                StatusLibraryNotificationType.AddBook => "Book added with name: {0}",
                StatusLibraryNotificationType.AddMovie => "Movie added with title: {0}",
                StatusLibraryNotificationType.UpdateBook => "Book updated with name: {0}",
                StatusLibraryNotificationType.UpdateMovie => "Movie updated with title: {0}",
                StatusLibraryNotificationType.DeleteBook => "Book deleted with name: {0}",
                StatusLibraryNotificationType.DeleteMovie => "Movie deleted with title: {0}",
                StatusLibraryNotificationType.MyBookListUpdated => "My Book List updated",
                StatusLibraryNotificationType.MyMovieListUpdated => "My Movie List updated",
                StatusLibraryNotificationType.BookReadStatusUpdated =>
                "{0} book read status has been changed to {1}",
                StatusLibraryNotificationType.MovieSeenStatusUpdated =>
                "{0} movie seen status has been changed to {1}",
                StatusLibraryNotificationType.AddSeries => "Series added with name: {0}",
                StatusLibraryNotificationType.UpdateSeries => "Series updated with name: {0}",
                StatusLibraryNotificationType.DeleteSeries => "Series deleted with name: {0}",
                StatusLibraryNotificationType.AddSeason => "Season added with number: {0}",
                StatusLibraryNotificationType.UpdateSeason => "Series updated with number: {0}",
                StatusLibraryNotificationType.DeleteSeason => "Series deleted with number: {0}",
                StatusLibraryNotificationType.AddEpisode => "Episode added with number: {0}",
                StatusLibraryNotificationType.UpdateEpisode => "Episode updated with number: {0}",
                StatusLibraryNotificationType.DeleteEpisode => "Series deleted with number: {0}",
                StatusLibraryNotificationType.AddMovieCategory => "Movie Category added with name: {0}",
                StatusLibraryNotificationType.UpdateMovieCategory => "Movie Category updated with name: {0}",
                StatusLibraryNotificationType.DeleteMovieCategory => "Movie Category deleted with name: {0}",
                StatusLibraryNotificationType.AddMovieComment => "Movie Comment added",
                StatusLibraryNotificationType.UpdateMovieComment => "Movie Comment updated",
                StatusLibraryNotificationType.DeleteMovieComment => "Movie Comment deleted",
                StatusLibraryNotificationType.MySeriesListUpdated => "My Series List updated",
                StatusLibraryNotificationType.SeriesSeenStatusUpdated =>
                "{0} series seen status has been changed to {1}",
                StatusLibraryNotificationType.SeasonSeenStatusUpdated =>
                "{0} series {1}. season sen status has been changed to {2}",
                StatusLibraryNotificationType.EpisodeSeenStatusUpdated =>
                "{0} series {1}. season {2}. episode seen status has been changed to {3}",
                _ =>
                throw new Exception("System Notification is not implemented"),
            };

            this.AddNotification(user, (int)type, val, args);
        }

        /// <inheritdoc />
        public int GetCountOfUnReadNotifications()
        {
            var user = this._utilsService.GetCurrentUser();

            int count = user.Notifications.Count(x => !x.IsRead);

            this._loggerService.LogInformation(user, nameof(NotificationService), "get count of unread notifications", 0);

            return count;
        }

        /// <inheritdoc />
        public List<NotificationDto> GetMyNotifications()
        {
            var user = this._utilsService.GetCurrentUser();

            var list = this._mapper.Map<List<NotificationDto>>(this._context.Notifications.Where(x => x.OwnerId == user.Id)
                .OrderByDescending(x => x.SentDate).ToList());

            this._loggerService.LogInformation(user, nameof(NotificationService), "get notifications",
                list.Select(x => x.Id).ToList());

            return list;
        }

        /// <inheritdoc />
        public void SetAsReadNotificationsById(int[] notifications)
        {
            var user = this._utilsService.GetCurrentUser();
            var list = this._context.Notifications.Where(x => notifications.ToList().Contains(x.Id)).ToList();

            foreach (var i in list)
            {
                i.IsRead = true;
            }

            this._context.Notifications.UpdateRange(list);
            this._context.SaveChanges();

            this._loggerService.LogInformation(user, nameof(NotificationService), "set notifications as read",
                list.Select(x => x.Id).ToList());
        }

        /// <inheritdoc />
        public void AddNotificationByType(Type type, object typeVal, User user, params string[] args)
        {
            if (type == typeof(SystemNotificationType))
            {
                this.AddSystemNotificationByType((SystemNotificationType)typeVal, user, args);
            }
            else if (type == typeof(WorkingManagerNotificationType))
            {
                this.AddWorkingManagerNotificationByType((WorkingManagerNotificationType)typeVal, user, args);
            }
            else if (type == typeof(StatusLibraryNotificationType))
            {
                this.AddStatusLibraryNotificationByType((StatusLibraryNotificationType)typeVal, user, args);
            }
        }
    }
}