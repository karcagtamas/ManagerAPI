using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services.Interfaces;

/// <summary>
/// Friend Service
/// </summary>
public interface IFriendService
{
    /// <summary>
    /// Get current user's friends
    /// Add notification rows
    /// </summary>
    /// <returns>List of friends</returns>
    List<FriendListDto> GetMyFriends();

    /// <summary>
    /// Remove current user's friend by Id
    /// Add notification rows
    /// </summary>
    /// <param name="friendId">Friend Id</param>
    void RemoveFriend(string friendId);

    /// <summary>
    /// Get current user's got friend requests
    /// </summary>
    /// <returns>List of friend requests</returns>
    List<FriendRequestListDto> GetMyFriendRequests();

    /// <summary>
    /// Send friend request response
    /// Add notification rows
    /// </summary>
    /// <param name="model">Model of response</param>
    void SendFriendRequestResponse(FriendRequestResponseModel model);

    /// <summary>
    /// Send friend request
    /// Add notification rows
    /// </summary>
    /// <param name="model">Model of the request</param>
    void SendFriendRequest(FriendRequestModel model);

    /// <summary>
    /// Get friend data
    /// </summary>
    /// <param name="friendId">Friend's Id</param>
    /// <returns>Friend data</returns>
    Task<FriendDataDto> GetFriendData(string friendId);
}
