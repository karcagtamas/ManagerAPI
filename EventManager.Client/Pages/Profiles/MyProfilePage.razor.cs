using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using EventManager.Client.Shared.Components.MyProfile;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EventManager.Client.Pages.Profiles;

/// <summary>
/// My Profile Page
/// </summary>
public partial class MyProfilePage
{
    [Inject]
    private IUserService UserService { get; set; } = default!;

    [Inject]
    private IAuthService AuthService { get; set; } = default!;

    [Inject]
    private IGenderService GenderService { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudForm Form { get; set; } = new MudForm();

    private UserDto? User { get; set; }
    private UserModel UserUpdate { get; set; } = new();
    private List<GenderListDto> Genders { get; set; } = new();
    private string Image { get; set; } = string.Empty;
    private string Roles { get; set; } = string.Empty;
    private bool ProfileIsLoading { get; set; } = true;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await this.GetUser();
        await this.GetGenders();
    }

    private async Task GetUser()
    {
        this.ProfileIsLoading = true;
        this.User = await this.UserService.GetUser();
        if (User is not null)
        {
            this.UserUpdate = new UserModel(User);
            this.Roles = string.Join(", ", this.User.Roles);
            if (User.ProfileImageData.Length != 0)
            {
                string base64 = Convert.ToBase64String(User.ProfileImageData);
                this.Image = $"data:image/gif;base64,{base64}";
            }
        }
        this.ProfileIsLoading = false;
        this.StateHasChanged();
    }

    private async Task GetGenders()
    {
        this.Genders = await this.GenderService.GetAll<GenderListDto>("Name");
    }

    private async Task Submit()
    {
        await Form.Validate();

        if (!Form.IsValid)
        {
            return;
        }

        if (await this.UserService.UpdateUser(this.UserUpdate))
        {
            await this.GetUser();
        }
    }

    private async void OpenUserDisableConfirmDialog()
    {
        var parameters = new DialogParameters
        {
            {
                "Input",
                new ConfirmDialogInput
                {
                    Name = "yourself",
                    Action = ConfirmType.Disable,
                    DeleteFunction = async () => await UserService.DisableUser()
                }
            }
        };
        var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await AuthService.Logout();
        }
    }

    private async void OpenChangePasswordDialog()
    {
        var parameters = new DialogParameters();
        var dialog = DialogService.Show<ChangePasswordDialog>("Change Password", parameters, new DialogOptions { MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await this.AuthService.Logout();
        }
    }

    private async void OpenUploadProfileImageDialog()
    {
        var parameters = new DialogParameters();
        var dialog = DialogService.Show<UploadProfileImageDialog>("Profile Image Upload", parameters, new DialogOptions { MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await this.GetUser();
        }
    }

    private async void OpenChangeUsernameDialog()
    {
        var parameters = new DialogParameters();
        var dialog = DialogService.Show<ChangeUsernameDialog>("Change Username", parameters, new DialogOptions { MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await this.AuthService.Logout();
        }
    }
}
