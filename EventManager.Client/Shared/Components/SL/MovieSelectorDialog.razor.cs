using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Movie Selector Dialog
    /// </summary>
    public partial class MovieSelectorDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        [Inject] private IMovieService MovieService { get; set; }
        private List<MyMovieSelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new List<int>();
        private bool IsLoading { get; set; } = false;

        private List<TableHeaderData<MyMovieSelectorListDto>> Header { get; set; } = new List<TableHeaderData<MyMovieSelectorListDto>>
        {
            new TableHeaderData<MyMovieSelectorListDto>("Title", Alignment.Left),
            new TableHeaderData<MyMovieSelectorListDto>("ReleaseYear", "Release Year", (e) => ((int) e).ToString(), Alignment.Right),
            new TableHeaderData<MyMovieSelectorListDto>("Creator", Alignment.Left)
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
            this.List = await this.MovieService.GetMySelectorList(false);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void Save()
        {
            var indexList = this.List.Where(x => x.IsMine).Select(x => x.Id).ToList();

            if (await this.MovieService.UpdateMyMovies(new MyMovieModel { Ids = indexList }))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void SwitchMineFlag(MyMovieSelectorListDto movie)
        {
            movie.IsMine = !movie.IsMine;
            if (movie.IsMine)
            {
                this.SelectedIndexList.Add(movie.Id);
            }
            else
            {
                this.SelectedIndexList.Remove(movie.Id);
            }
        }
    }
}