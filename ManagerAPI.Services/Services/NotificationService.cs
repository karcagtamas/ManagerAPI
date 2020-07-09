using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManagerAPI.DataAccess;
using ManagerAPI.Models.DTOs;
using ManagerAPI.Models.Entities;
using ManagerAPI.Models.Enums;
using ManagerAPI.Services.Services.Interfaces;

namespace ManagerAPI.Services.Services
{
    /// <summary>
    /// Service for managing notifications
    /// </summary>
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
        public NotificationService(IUtilsService utilsService, DatabaseContext context, IMapper mapper, ILoggerService loggerService)
        {
            _utilsService = utilsService;
            _context = context;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Add System notification by given type
        /// </summary>
        /// <param name="type">Type of notification</param>
        /// <param name="user">Destination user</param>
        public void AddSystemNotificationByType(SystemNotificationType type, User user)
        {
            if (user == null) {
                throw new ArgumentException("User cannot be null");
            }
            // Determine message by type
            string val = type
            switch
            {
                SystemNotificationType.Login => $"Successfully logged in. Welcome.",
                SystemNotificationType.Logout => $"Successfully logged out.",
                SystemNotificationType.Registration => $"Successfully registered. Have fun.",
                SystemNotificationType.MessageArrived => $"You have a new unread message.",
                SystemNotificationType.MyProfileUpdated => $"You profile data successfully updated",
                SystemNotificationType.ToDoAdded => $"ToDo successfully added. Do not forget it.",
                SystemNotificationType.ToDoDeleted => $"ToDo successfully deleted.",
                SystemNotificationType.ToDoUpdated => $"ToDo successfully updated.",
                SystemNotificationType.PasswordChanged => $"Password changed",
                SystemNotificationType.ProfileImageChanged => $"Profile image changed",
                SystemNotificationType.UsernameChanged => $"Username changed",
                SystemNotificationType.ProfileDisabled => $"Profile disabled",
                SystemNotificationType.FriendRequestReceived => $"Friend request received",
                SystemNotificationType.FriendRequestSent => $"Friend request sent",
                SystemNotificationType.FriendRequestAccepted => $"Friend request accepted",
                SystemNotificationType.FriendRequestDeclined => $"Friend request declined",
                SystemNotificationType.YouHasANewFriend => $"You has a new friend",
                SystemNotificationType.FriendRemoved => $"Friend removed",
                SystemNotificationType.NewsAdded => $"News added",
                SystemNotificationType.NewsUpdated => $"News updated",
                SystemNotificationType.NewsDeleted => $"News deleted",
                _ =>
                throw new Exception("System Notification is not implemented"),
            };

            // Create notification
            var notification = new Notification
            {
                Content = val,
                OwnerId = user.Id,
                TypeId = (int)type
            };

            // Save notification
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            _loggerService.LogInformation(user, nameof(NotificationService), "add notification", notification.Id);
        }

        /// <summary>
        /// Get count of unread notifications
        /// </summary>
        /// <returns>Count</returns>
        public int GetCountOfUnReadNotifications()
        {
            var user = _utilsService.GetCurrentUser();

            var count = user.Notifications.Where(x => !x.IsRead).Count();

            _loggerService.LogInformation(user, nameof(NotificationService), "get count of unread notifications", 0);

            return count;
        }

        /// <summary>
        /// Get current logged in user's notifications
        /// </summary>
        /// <returns>List of notifications</returns>
        public List<NotificationDto> GetMyNotifications()
        {
            var user = _utilsService.GetCurrentUser();

            var list = _mapper.Map<List<NotificationDto>>(_context.Notifications.Where(x => x.OwnerId == user.Id).OrderByDescending(x => x.SentDate).ToList());

            _loggerService.LogInformation(user, nameof(NotificationService), "get notifications", list.Select(x => x.Id).ToList());

            return list;
        }

        /// <summary>
        /// Set notifications as read
        /// </summary>
        /// <param name="notifications">Ids of the notifications</param>
        public void SetAsReadNotificationsById(int[] notifications)
        {
            var user = _utilsService.GetCurrentUser();
            var list = _context.Notifications.Where(x => notifications.ToList().Contains(x.Id)).ToList();

            foreach (var i in list)
            {
                i.IsRead = true;
            }

            _context.Notifications.UpdateRange(list);
            _context.SaveChanges();

            _loggerService.LogInformation(user, nameof(NotificationService), "set notifications as read", list.Select(x => x.Id).ToList());
        }
    }
}