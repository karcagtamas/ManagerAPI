// unset

using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Episode Editor Component
    /// </summary>
    public partial class EpisodeEditorComponent
    {
        /// <summary>
        /// Episode
        /// </summary>
        [Parameter]
        public MyEpisodeListDto Episode { get; set; }
        
        /// <summary>
        /// Series is mine
        /// </summary>
        [Parameter]
        public bool SeriesIsMine { get; set; }
        
        /// <summary>
        /// Can delete
        /// </summary>
        [Parameter]
        public bool CanDelete { get; set; }
        
        /// <summary>
        /// Episode has been changed
        /// </summary>
        [Parameter]
        public EventCallback Changed { get; set; }
        
        [Inject]
        private NavigationManager Navigation { get; set; }
        
        [Inject]
        private IEpisodeService EpisodeService { get; set; }
        
        [Inject] 
        private IDialogService DialogService { get; set; }

        private bool IsClosed { get; set; } = true;
        
        private void OpenEpisode()
        {
            this.Navigation.NavigateTo($"/episodes/{Episode.Id}");
        }
        
        private async void SetEpisodeSeenStatus(bool status)
        {
            if (await this.EpisodeService.UpdateSeenStatus(
                new List<EpisodeSeenStatusModel> {new() {Id = Episode.Id, Seen = status}}))
            {
                await Changed.InvokeAsync();
            }
        }
        
        private async void OpenDeleteEpisodeDialog()
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = Episode.Title,
                        Action = ConfirmType.Delete,
                        DeleteFunction = async () => await EpisodeService.DeleteDecremented(Episode.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Episode Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await Changed.InvokeAsync();
            }
        }
    }
}