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

        private EpisodeShortModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private EpisodeDto? Episode { get; set; }

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
                this.Episode = await this.EpisodeService.Get<EpisodeDto>((int)this.EpisodeId);
                this.Model = Episode is not null ? new EpisodeShortModel(this.Episode) : new EpisodeShortModel();
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
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