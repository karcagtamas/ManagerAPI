using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services.Interfaces
{
    public interface IFriendService
    {
        List<FriendListDto> GetMyFriends();
        void RemoveFriend(string friendId);
        List<FriendRequestListDto> GetMyFriendRequests();
        void SendFriendRequestResponse(FriendRequestResponseModel model);
        void SendFriendRequest(FriendRequestModel model);
        Task<FriendDataDto> GetFriendData(string friendId);
    }
}