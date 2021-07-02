using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Message Service
    /// </summary>
    public interface IMessageService : IHttpCall<MessageListDto, MessageDto, MessageModel>
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