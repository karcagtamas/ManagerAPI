using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.Auth
{
    /// <summary>
    /// Registration Page
    /// </summary>
    public partial class RegistrationPage
    {
        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string Title { get; set; } = "Registration";
        private RegistrationModel Model { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.Model = new RegistrationModel
            {
                UserName = "",
                Email = "",
                FullName = "",
                Password = "",
                PasswordConfirm = ""
            };
        }

        private void Navigate(string path)
        {
            this.NavigationManager.NavigateTo(path);
        }

        private async Task SignUp()
        {
            await this.AuthService.Register(this.Model);
            this.Model = new RegistrationModel
            {
                UserName = "",
                Email = "",
                FullName = "",
                Password = "",
                PasswordConfirm = ""
            };
        }
    }
}