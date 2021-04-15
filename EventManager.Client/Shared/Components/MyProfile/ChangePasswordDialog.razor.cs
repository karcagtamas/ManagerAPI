using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace EventManager.Client.Shared.Components.MyProfile
{
    /// <summary>
    /// Change Password Dialog
    /// </summary>
    public partial class ChangePasswordDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject] private IUserService UserService { get; set; }

        private PasswordUpdateModifyModel PasswordUpdate { get; set; }

        private EditContext Context { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.PasswordUpdate = new PasswordUpdateModifyModel
            {
                NewPassword = "", OldPassword = "", ConfirmNewPassword = ""
            };

            this.Context = new EditContext(this.PasswordUpdate);
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (await this.UserService.UpdatePassword(new PasswordUpdateModel
            {
                NewPassword = this.PasswordUpdate.NewPassword, OldPassword = this.PasswordUpdate.OldPassword
            }))
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