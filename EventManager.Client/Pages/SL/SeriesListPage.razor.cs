using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    /// <summary>
    /// Series List Page
    /// </summary>
    public partial class SeriesListPage
    {
        [Inject] private ISeriesService SeriesService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private List<SeriesListDto> SeriesList { get; set; }
        private bool IsLoading { get; set; }
        private bool CanAdd { get; set; }

        private List<TableHeaderData<SeriesListDto>> Header { get; set; } = new List<TableHeaderData<SeriesListDto>>
        {
            new TableHeaderData<SeriesListDto>("Title", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
            new TableHeaderData<SeriesListDto>("StartYear", "Start Year", true,
                (e) => WriteHelper.WriteNullableField((int?) e), Alignment.Right),
            new TableHeaderData<SeriesListDto>("Creator", true, Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSeries();
            this.CanAdd = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
        }

        private async Task GetSeries()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.SeriesList = await this.SeriesService.GetAll<SeriesListDto>("Title");
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(SeriesListDto series)
        {
            this.Navigation.NavigateTo($"/series/{series.Id}");
        }

        private async void OpenAddSeriesDialog()
        {
            var parameters = new DialogParameters { { "SeriesId", null } };
            var dialog = DialogService.Show<SeriesDialog>("Add Series", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeries();
            }
        }
    }
}