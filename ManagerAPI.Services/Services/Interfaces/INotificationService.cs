using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Domain.Enums.WM;
using ManagerAPI.Shared.DTOs;
using System;
using System.Collections.Generic;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Service for managing notifications
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Add notification
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="type">Type of notification</param>
        /// <param name="val">String base text</param>
        /// <param name="args">Inject params</param>
        void AddNotification(User user, int type, string val, params string[] args);


        /// <summary>
        /// Add notification by type
        /// </summary>
        /// <param name="type">Type of type</param>
        /// <param name="typeVal">Type value</param>
        /// <param name="user">User</param>
        /// <param name="args">Args</param>
        void AddNotificationByType(Type type, object typeVal, User user, params string[] args);

        /// <summary>
        /// Add System notification by given type
        /// </summary>
        /// <param name="type">Type of notification</param>
        /// <param name="user">Destination user</param>
        /// <param name="args">Inject arguments</param>
        void AddSystemNotificationByType(SystemNotificationType type, User user, params string[] args);

        /// <summary>
        /// Add Working Manager notification by given type.
        /// </summary>
        /// <param name="type">Type of notification</param>
        /// <param name="user">Destination user</param>
        /// <param name="args">Inject arguments</param>
        void AddWorkingManagerNotificationByType(WorkingManagerNotificationType type, User user, params string[] args);

        /// <summary>
        /// Add Status Library notification by given type
        /// </summary>
        /// <param name="type">Type of notification</param>
        /// <param name="user">Destination user</param>
        /// <param name="args">Inject arguments</param>
        void AddStatusLibraryNotificationByType(StatusLibraryNotificationType type, User user, params string[] args);

        /// <summary>
        /// Get current logged in user's notifications
        /// </summary>
        /// <returns>List of notifications</returns>
        List<NotificationDto> GetMyNotifications();

        /// <summary>
        /// Get count of unread notifications
        /// </summary>
        /// <returns>Count</returns>
        int GetCountOfUnReadNotifications();

        /// <summary>
        /// Set notifications as read
        /// </summary>
        /// <param name="notifications">Ids of the notifications</param>
        void SetAsReadNotificationsById(int[] notifications);
    }
}