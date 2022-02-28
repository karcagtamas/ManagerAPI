using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Friend Service
    /// </summary>
    public interface IFriendService
    {
        /// <summary>
        /// Get friend requests
        /// </summary>
        /// <returns>List of requests</returns>
        Task<List<FriendRequestListDto>> GetMyFriendRequests();

        /// <summary>
        /// Get friends
        /// </summary>
        /// <returns>List of friends</returns>
        Task<List<FriendListDto>> GetMyFriends();

        /// <summary>
        /// Remove friend by Id
        /// </summary>
        /// <param name="friendId">Friend Id</param>
        Task<bool> RemoveFriend(string friendId);

        /// <summary>
        /// Send friend request
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> SendFriendRequest(FriendRequestModel model);

        /// <summary>
        /// Send friend request response
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> SendFriendRequestResponse(FriendRequestResponseModel model);

        /// <summary>
        /// Get friend data by Id
        /// </summary>
        /// <param name="friendId">Friend Idd</param>
        Task<FriendDataDto?> GetFriendData(string friendId);
    }
}