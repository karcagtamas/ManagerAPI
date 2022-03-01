using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
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
    public partial class SeriesDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Series Id
        /// </summary>
        [Parameter]
        public int? SeriesId { get; set; }

        [Inject] private ISeriesService SeriesService { get; set; }

        private SeriesModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private SeriesDto? Series { get; set; }

        /// <inheritdoc />        
        protected override async Task OnInitializedAsync()
        {
            this.Model = new SeriesModel
            {
                Title = "",
                Description = "",
                StartYear = null,
                EndYear = null
            };

            this.Context = new EditContext(this.Model);

            if (this.SeriesId != null)
            {
                this.Series = await this.SeriesService.Get<SeriesDto>((int)this.SeriesId);
                this.Model =  Series is not null ? new SeriesModel(this.Series) : new SeriesModel();
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (SeriesId == null)
                {
                    return;
                }

                if (await this.SeriesService.Update((int)SeriesId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.SeriesService.Create(this.Model))
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