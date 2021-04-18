using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.Friends;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.Friends
{
    /// <summary>
    /// My Friend List page
    /// </summary>
    public partial class MyFriendListPage
    {
        [Inject]
        private IFriendService FriendService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private List<FriendListDto> Friends { get; set; }
        private List<FriendRequestListDto> FriendRequests { get; set; }
        private bool MyFriendsIsLoading { get; set; }
        private bool MyFriendRequestsIsLoading { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetFriends();
            await this.GetFriendRequests();
        }

        private async Task GetFriendRequests()
        {
            this.MyFriendRequestsIsLoading = true;
            this.StateHasChanged();
            this.FriendRequests = await this.FriendService.GetMyFriendRequests();
            this.MyFriendRequestsIsLoading = false;
            this.StateHasChanged();
        }

        private async Task GetFriends()
        {
            this.MyFriendsIsLoading = true;
            this.StateHasChanged();
            this.Friends = await this.FriendService.GetMyFriends();
            this.MyFriendsIsLoading = false;
            this.StateHasChanged();
        }

        private async Task SendFriendRequestResponse(int id, bool response)
        {
            if (await this.FriendService.SendFriendRequestResponse(new FriendRequestResponseModel
            {
                RequestId = id,
                Response = response
            }))
            {
                await this.GetFriendRequests();
                await this.GetFriends();
            }
        }

        private async void OpenFriendRequestDialog()
        {
            var parameters = new DialogParameters();

            var dialog = this.DialogService.Show<FriendRequestDialog>("Friend request", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetFriendRequests();
            }
        }

        private async void OpenFriendDataModal(string friendId)
        {
            var parameters = new DialogParameters {{"FriendId", friendId}};

            var dialog = this.DialogService.Show<FriendData>("Friend data", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetFriends();
            }
        }
    }
}