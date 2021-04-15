using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace EventManager.Client.Shared.Components.MyProfile
{
    /// <summary>
    /// Change Username Dialog
    /// </summary>
    public partial class ChangeUsernameDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private IModalService ModalService { get; set; }

        private UsernameUpdateModel UsernameUpdate { get; set; }

        private EditContext Context { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.UsernameUpdate = new UsernameUpdateModel
            {
                UserName = ""
            };

            this.Context = new EditContext(this.UsernameUpdate);
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (await this.UserService.UpdateUsername(this.UsernameUpdate))
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