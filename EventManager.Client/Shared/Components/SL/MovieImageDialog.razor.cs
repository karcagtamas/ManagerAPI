using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.Models.SL;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Movie Image Dialog
    /// </summary>
    public partial class MovieImageDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Movie Id
        /// </summary>
        [Parameter]
        public int MovieId { get; set; }
        [Inject] private IMovieService MovieService { get; set; }
        [Inject] private ISnackbar Toaster { get; set; }

        private IBrowserFile File { get; set; }

        private List<string> ImageExtensions { get; set; } = new List<string>
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
                    await using var stream = new MemoryStream();
                    await this.File.OpenReadStream().CopyToAsync(stream);

                    if (!await this.MovieService.UpdateImage(this.MovieId,
                        new MovieImageModel { ImageData = stream.ToArray(), ImageTitle = this.File.Name }))
                    {
                        return;
                    }

                    Dialog.Close(DialogResult.Ok(true));
                }
                catch (Exception e)
                {
                    Toaster.Add("Problem during the image uploading. Please try again later.", Severity.Error);
                    Console.WriteLine(e);
                }
            }
            else
            {
                this.Toaster.Add("Invalid file extension. Please try again with a correct type.", Severity.Error);
            }
        }

        private void FilesReady(InputFileChangeEventArgs e)
        {
            this.File = e.GetMultipleFiles().FirstOrDefault();
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}