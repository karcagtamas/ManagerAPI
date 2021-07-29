using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.Auth
{
    /// <summary>
    /// Login Page
    /// </summary>
    public partial class LoginPage
    {
        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string Title { get; set; } = "Login";
        private LoginModel Model { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.Model = new LoginModel
            {
                UserName = "",
                Password = ""
            };
        }

        private void Navigate(string path)
        {
            this.NavigationManager.NavigateTo(path);
        }

        private async Task SignIn()
        {
            if (!string.IsNullOrEmpty(await this.AuthService.Login(this.Model)))
            {
                this.NavigationManager.NavigateTo("/");
            }
        }
    }
}