using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EventManager.Client.Shared.Components.MyProfile
{
    public partial class ChangePasswordDialog
    {
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [CascadingParameter]
        public BlazoredModal BlazoredModal { get; set; }

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private IModalService ModalService { get; set; }

        public int FormId { get; set; }

        protected PasswordUpdateModifyModel PasswordUpdate { get; set; }

        public EditContext Context { get; set; }

        protected override void OnInitialized()
        {
            this.FormId = this.Parameters.Get<int>("FormId");

            ((ModalService)this.ModalService).OnConfirm += this.OnConfirm;

            this.PasswordUpdate = new PasswordUpdateModifyModel
            {
                NewPassword = "",
                OldPassword = "",
                ConfirmNewPassword = ""
            };

            this.Context = new EditContext(this.PasswordUpdate);
        }

        protected async void OnConfirm()
        {
            bool isValid = this.Context.Validate();
            if (isValid && await this.UserService.UpdatePassword(new PasswordUpdateModel
            {
                NewPassword = this.PasswordUpdate.NewPassword,
                OldPassword = this.PasswordUpdate.OldPassword
            }))
            {
                this.ModalService.Close(ModalResult.Ok<bool>(true));
                ((ModalService)this.ModalService).OnConfirm -= this.OnConfirm;
            }
        }
    }
}