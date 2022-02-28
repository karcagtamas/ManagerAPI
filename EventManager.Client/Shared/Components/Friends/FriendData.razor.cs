// unset

using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using ManagerAPI.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.Friends
{
    /// <summary>
    /// Friend Data
    /// </summary>
    public partial class FriendData
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        private bool ShowForm { get; set; } = true;
        
        [Inject]
        private IFriendService FriendService { get; set; }
        
        [Inject]
        private IDialogService DialogService { get; set; }
        
        /// <summary>
        /// Friend
        /// </summary>
        [Parameter]
        public string FriendId { get; set; }
        private FriendDataDto? Friend { get; set; }
        private bool IsLoading { get; set; } = true;

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await GetFriendData();
        }

        private async Task GetFriendData()
        {
            this.IsLoading = true;
            this.Friend = await FriendService.GetFriendData(this.FriendId);
            this.IsLoading = false;
        }

        private async void RemoveFriend()
        {
            var parameters = new DialogParameters {{"Input", new ConfirmDialogInput
            {
                DeleteFunction = async () => await FriendService.RemoveFriend(this.FriendId),
                Action = ConfirmType.Delete,
                Name = Friend.UserName
            }}};
            var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                Dialog.Close(DialogResult.Ok(true));
            }
        }
        
        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}