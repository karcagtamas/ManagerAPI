using System.Collections.Generic;
using ManagerAPI.Models.DTOs;
using ManagerAPI.Models.Models;

namespace ManagerAPI.Services.Services
{
    public interface IFriendService
    {
        List<FriendListDto> GetMyFriends();
        void RemoveFriend(int friendId);
        List<FriendRequestListDto> GetMyFriendRequests(bool? type);
        void SendFriendRequestResponse(FriendRequestResponseModel model);
        void SendFriendRequest(int destinationUser);
    }
}