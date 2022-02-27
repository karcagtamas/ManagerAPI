using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Message Service
    /// </summary>
    public interface IMessageService : INotificationRepository<Message, int>
    {
        /// <summary>
        /// Get current user's messages
        /// </summary>
        /// <param name="friendId">Partner Id</param>
        /// <returns>List of messages</returns>
        List<MessageDto> GetMessages(string friendId);

        /// <summary>
        /// Send message to partner
        /// </summary>
        /// <param name="model">Model of message sending</param>
        void SendMessage(MessageModel model);
    }
}