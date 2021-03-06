using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    public partial class MySeriesListPage
    {
        [Inject] private ISeriesService SeriesService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IModalService Modal { get; set; }

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

        protected override async Task OnInitializedAsync()
        {
            await this.GetMovies();
        }

        private async Task GetMovies()
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

        private void OpenEditMySeriesDialog()
        {
            var parameters = new ModalParameters();
            parameters.Add("FormId", 1);

            var options = new ModalOptions
            {
                ButtonOptions = { ConfirmButtonType = ConfirmButton.Save, ShowConfirmButton = true }
            };

            this.Modal.OnClose += this.EditMySeriesDialogClosed;

            this.Modal.Show<SeriesSelectorDialog>("Edit My Series", parameters, options);
        }

        private async void EditMySeriesDialogClosed(ModalResult modalResult)
        {
            if (!modalResult.Cancelled && (bool)modalResult.Data)
            {
                await this.GetMovies();
            }

            this.Modal.OnClose -= this.EditMySeriesDialogClosed;
        }
    }
}