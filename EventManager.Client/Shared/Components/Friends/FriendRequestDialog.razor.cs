using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace EventManager.Client.Shared.Components.Friends
{
    /// <summary>
    /// Friend Request Dialog
    /// </summary>
    public partial class FriendRequestDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject] private IFriendService FriendService { get; set; }
        private FriendRequestModel Model { get; set; }
        private EditContext Context { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.Model = new FriendRequestModel {DestinationUserName = "", Message = ""};

            this.Context = new EditContext(this.Model);
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (await FriendService.SendFriendRequest(this.Model))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}