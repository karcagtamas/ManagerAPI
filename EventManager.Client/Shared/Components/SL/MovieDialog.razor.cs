using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Movie Dialog
    /// </summary>
    public partial class MovieDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Movie Id
        /// </summary>
        [Parameter]
        public int? MovieId { get; set; }

        [Inject] private IMovieService MovieService { get; set; }

        private MovieModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private MovieDto Movie { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new MovieModel
            {
                Title = "",
                Description = "",
                ReleaseYear = DateTime.Now.Year
            };

            this.Context = new EditContext(this.Model);

            if (MovieId != null)
            {
                this.Movie = await this.MovieService.Get((int)this.MovieId);
                this.Model = new MovieModel(this.Movie);
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (MovieId == null)
                {
                    return;
                }

                if (await this.MovieService.Update((int)MovieId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.MovieService.Create(this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}