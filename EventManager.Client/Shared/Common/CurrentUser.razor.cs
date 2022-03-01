using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace EventManager.Client.Shared.Common
{
    /// <summary>
    /// Current User display Component
    /// </summary>
    public partial class CurrentUser
    {
        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private INotificationService NotificationService { get; set; }

        private UserShortDto? User { get; set; }
        private int UnReadNotificationCount { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.User = null;
            await this.GetUser();
            await this.GetCountOfUnreadNotifications();
        }

        private async Task GetUser()
        {
            this.User = await this.UserService.GetShortUser();
        }

        private async Task GetCountOfUnreadNotifications()
        {
            int? val = await this.NotificationService.GetCountOfUnReadNotifications();
            this.UnReadNotificationCount = val == null ? 0 : (int)val;
        }

        private async Task Logout()
        {
            await this.AuthService.Logout();
        }
    }
}