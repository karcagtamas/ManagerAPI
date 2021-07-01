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
    /// My Series List Page
    /// </summary>
    public partial class MySeriesListPage
    {
        [Inject] private ISeriesService SeriesService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        private List<MySeriesListDto> SeriesList { get; set; }
        private bool IsLoading { get; set; }

        private List<TableHeaderData<MySeriesListDto>> Header { get; set; } = new List<TableHeaderData<MySeriesListDto>>
        {
            new TableHeaderData<MySeriesListDto>("Title", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
            new TableHeaderData<MySeriesListDto>("StartYear","Start Year", true,
                (e) => WriteHelper.WriteNullableField((int?) e), Alignment.Right),
            new TableHeaderData<MySeriesListDto>("Creator", true, Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSeriesList();
        }

        private async Task GetSeriesList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.SeriesList = await this.SeriesService.GetMyList();
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(MySeriesListDto series)
        {
            this.Navigation.NavigateTo($"/series/{series.Id}");
        }

        private async void OpenEditMySeriesDialog()
        {
            var parameters = new DialogParameters();
            var dialog = DialogService.Show<SeriesSelectorDialog>("Edit My Series List", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeriesList();
            }
        }
    }
}