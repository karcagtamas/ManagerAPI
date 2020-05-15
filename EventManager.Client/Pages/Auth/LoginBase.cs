using System;
using System.Threading.Tasks;
using EventManager.Client.Models;
using EventManager.Client.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace EventManager.Client.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        [Inject] 
        private IAuthService AuthService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IHelperService HelperService { get; set; }
        
        [Inject]
        private IMatToaster Toaster { get; set; }

        protected string Title { get; set; } = "Login";
        protected LoginModel Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginModel
            {
                UserName = "",
                Password = ""
            };
            base.OnInitialized();
        }
        
        protected void Navigate(string path)
        {
            NavigationManager.NavigateTo(path);
        }

        protected async Task SignIn()
        {
            try
            {
                var result = await AuthService.Login(Model);
                if (result.IsSuccess)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Toaster.Add(result.Message, MatToastType.Danger, "Login Error");
                }
            }
            catch (Exception e)
            {
                Toaster.Add(HelperService.ConnectionIsUnreachable(), MatToastType.Danger, "Login Error");
                Console.WriteLine(e);
            }
        }
    }
}