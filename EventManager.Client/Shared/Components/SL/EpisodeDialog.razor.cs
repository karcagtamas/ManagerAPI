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
    /// Episode Dialog
    /// </summary>
    public partial class EpisodeDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Episode Id
        /// </summary>
        [Parameter]
        public int? EpisodeId { get; set; }

        [Inject] private IEpisodeService EpisodeService { get; set; }

        [Inject] private IModalService ModalService { get; set; }

        private EpisodeShortModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private EpisodeDto Episode { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new EpisodeShortModel
            {
                Description = ""
            };

            this.Context = new EditContext(this.Model);

            if (this.EpisodeId != null)
            {
                this.Episode = await this.EpisodeService.Get((int)this.EpisodId);
                this.Model = new EpisodeShortModel(this.Episode);
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void OnConfirm()
        {
            bool isValid = this.Context.Validate();
            if (this.IsEdit)
            {
                if (isValid && await this.EpisodeService.UpdateShort(this.Id, this.Model))
                {
                    this.ModalService.Close(ModalResult.Ok(true));
                    ((ModalService)this.ModalService).OnConfirm -= this.OnConfirm;
                }
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (EpisodeId == null)
                {
                    return;
                }

                if (await this.EpisodeService.UpdateShort((int)this.EpisodeId, this.Model))
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