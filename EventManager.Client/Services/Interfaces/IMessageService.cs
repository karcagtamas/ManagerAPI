using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Message Service
    /// </summary>
    public interface IMessageService : IHttpCall<int>
    {
        /// <summary>
        /// Get messages
        /// </summary>
        /// <param name="friendId">Friend Id</param>
        /// <returns>List of messages</returns>
        Task<List<MessageDto>> GetMessages(int friendId);

        /// <summary>
        /// Send new message
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> SendMessage(MessageModel model);
    }
}