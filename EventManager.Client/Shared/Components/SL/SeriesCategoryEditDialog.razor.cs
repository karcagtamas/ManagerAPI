using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Series Dialog
    /// </summary>
    public partial class SeriesCategoryEditDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Series Category Id
        /// </summary>
        [Parameter]
        public int? SeriesCategoryId { get; set; }

        [Inject] private ISeriesCategoryService SeriesCategoryService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private SeriesCategoryModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private SeriesCategoryDto? SeriesCategory { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new SeriesCategoryModel
            {
                Name = ""
            };

            this.Context = new EditContext(this.Model);

            if (SeriesCategoryId != null)
            {
                this.SeriesCategory = await this.SeriesCategoryService.Get<SeriesCategoryDto>((int)this.SeriesCategoryId);
                this.Model = SeriesCategory is not null ? new SeriesCategoryModel(this.SeriesCategory) : new SeriesCategoryModel();
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (SeriesCategoryId == null)
                {
                    return;
                }

                if (await this.SeriesCategoryService.Update((int)SeriesCategoryId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.SeriesCategoryService.Create(this.Model))
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
                Name = SeriesCategory.Name,
                Action = ConfirmType.Delete
            }}};
            var dialog = DialogService.Show<ConfirmDialog>("Series Category Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                if (await SeriesCategoryService.Delete(SeriesCategory.Id))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
        }
    }
}