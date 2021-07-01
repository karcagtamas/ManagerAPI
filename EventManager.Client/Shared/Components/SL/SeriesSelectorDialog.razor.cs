using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Series Selector Dialog
    /// </summary>
    public partial class SeriesSelectorDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        [Inject] private ISeriesService SeriesService { get; set; }
        private List<MySeriesSelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new List<int>();
        private bool IsLoading { get; set; } = false;

        private List<TableHeaderData<MySeriesSelectorListDto>> Header { get; set; } = new List<TableHeaderData<MySeriesSelectorListDto>>
        {
            new TableHeaderData<MySeriesSelectorListDto>("Title", Alignment.Left),
            new TableHeaderData<MySeriesSelectorListDto>("StartYear", "Start Year", (e) => WriteHelper.WriteNullableField((int?) e), Alignment.Right),
            new TableHeaderData<MySeriesSelectorListDto>("Creator", Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSelectorList();
            this.SelectedIndexList = this.List.Where(x => x.IsMine).Select(x => x.Id).ToList();
        }

        private async Task GetSelectorList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.List = await this.SeriesService.GetMySelectorList(false);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void Save()
        {
            var indexList = this.List.Where(x => x.IsMine).Select(x => x.Id).ToList();

            if (await this.SeriesService.UpdateMySeries(new MySeriesModel { Ids = indexList }))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void SwitchMineFlag(MySeriesSelectorListDto series)
        {
            series.IsMine = !series.IsMine;
            if (series.IsMine)
            {
                this.SelectedIndexList.Add(series.Id);
            }
            else
            {
                this.SelectedIndexList.Remove(series.Id);
            }
        }
    }
}