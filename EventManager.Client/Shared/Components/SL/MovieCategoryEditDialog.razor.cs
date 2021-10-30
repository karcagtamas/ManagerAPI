using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
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
    public partial class MovieCategoryEditDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Movie Category Id
        /// </summary>
        [Parameter]
        public int? MovieCategoryId { get; set; }

        [Inject] private IMovieCategoryService MovieCategoryService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private MovieCategoryModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private MovieCategoryDto MovieCategory { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new MovieCategoryModel
            {
                Name = ""
            };

            this.Context = new EditContext(this.Model);

            if (MovieCategoryId != null)
            {
                this.MovieCategory = await this.MovieCategoryService.Get((int)this.MovieCategoryId);
                this.Model = new MovieCategoryModel(this.MovieCategory);
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (MovieCategoryId == null)
                {
                    return;
                }

                if (await this.MovieCategoryService.Update((int)MovieCategoryId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.MovieCategoryService.Create(this.Model))
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

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters {{"Input", new ConfirmDialogInput
            {
                Name = MovieCategory.Name,
                Action = ConfirmType.Delete
            }}};
            var dialog = DialogService.Show<ConfirmDialog>("Movie Category Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                if (await MovieCategoryService.Delete(MovieCategory.Id))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
        }
    }
}