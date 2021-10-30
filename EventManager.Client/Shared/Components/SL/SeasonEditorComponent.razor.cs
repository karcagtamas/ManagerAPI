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
    /// Season Editor Component
    /// </summary>
    public partial class SeasonEditorComponent
    {
        /// <summary>
        /// Season
        /// </summary>
        [Parameter]
        public MySeasonDto Season { get; set; }

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
        /// Can add or edit
        /// </summary>
        [Parameter]
        public bool CanAddOrEdit { get; set; }

        /// <summary>
        /// Episode has been changed
        /// </summary>
        [Parameter]
        public EventCallback Changed { get; set; }

        [Inject] private ISeasonService SeasonService { get; set; }

        [Inject] private IEpisodeService EpisodeService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private bool IsClosed { get; set; } = true;

        private async void OpenDeleteSeasonDialog()
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = Season.Number.ToString(),
                        Action = ConfirmType.Delete,
                        DeleteFunction = async () => await SeasonService.DeleteDecremented(Season.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Season Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await Changed.InvokeAsync();
            }
        }

        private async void AddIncrementedEpisode()
        {
            if (await this.EpisodeService.AddIncremented(Season.Id, 1))
            {
                await Changed.InvokeAsync();
            }
        }

        private async void AddMultipleIncrementedEpisode()
        {
            var parameters = new DialogParameters { { "Input", new NumberInputDialogInput { Name = "episode creation", DefaultValue = 2 } } };
            var dialog = DialogService.Show<NumberInputDialog>("Number Input", parameters,
                new DialogOptions { FullWidth = true, MaxWidth = MaxWidth.Small });
            var result = await dialog.Result;

            if (await this.EpisodeService.AddIncremented(Season.Id, (int)result.Data))
            {
                await Changed.InvokeAsync();
            }
        }

        private async void SetSeasonSeenStatus(bool status)
        {
            if (await this.SeasonService.UpdateSeenStatus(
                new List<SeasonSeenStatusModel> { new SeasonSeenStatusModel { Id = Season.Id, Seen = status } }))
            {
                await Changed.InvokeAsync();
            }
        }
    }
}