using ManagerAPI.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Notification Service
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Get my notifications
        /// </summary>
        /// <returns>List of notifications</returns>
        Task<List<NotificationDto>> GetMyNotifications();

        /// <summary>
        /// Set all not read notifications to read
        /// </summary>
        /// <param name="ids">Id List</param>
        Task<bool> SetUnReadsToRead(int[] ids);

        /// <summary>
        /// Get count of not read notifications
        /// </summary>
        /// <returns></returns>
        Task<int?> GetCountOfUnReadNotifications();
    }
}