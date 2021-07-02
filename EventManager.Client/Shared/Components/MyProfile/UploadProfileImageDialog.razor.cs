using EventManager.Client.Services.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventManager.Client.Shared.Components.MyProfile
{
    /// <summary>
    /// Upload Profile Image Dialog
    /// </summary>
    public partial class UploadProfileImageDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject] private IUserService UserService { get; set; }

        [Inject] private ISnackbar Snackbar { get; set; }
        private IBrowserFile File { get; set; }

        private List<string> ImageExtensions { get; set; } = new()
        {
            "image/jpg",
            "image/jpeg",
            "image/png",
            "image/bmp"
        };

        private async void Save()
        {
            if (this.File == null)
            {
                return;
            }

            if (this.ImageExtensions.Contains(this.File.ContentType))
            {
                try
                {
                    await using var memoryStream = new MemoryStream();
                    await this.File.OpenReadStream().CopyToAsync(memoryStream);
                    if (await this.UserService.UpdateProfileImage(memoryStream.ToArray()))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }
                }
                catch (Exception e)
                {
                    Snackbar.Add("Problem during the image uploading. Please try again later.", Severity.Error);
                    Console.WriteLine(e);
                }
            }
            else
            {
                Snackbar.Add("Invalid file extension. Please try again with a correct type.", Severity.Error);
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void FilesReady(InputFileChangeEventArgs e)
        {
            this.File = e.GetMultipleFiles().FirstOrDefault();
        }
    }
}