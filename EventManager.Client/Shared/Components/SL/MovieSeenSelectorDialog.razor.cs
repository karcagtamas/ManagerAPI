using EventManager.Client.Enums;
using EventManager.Client.Models;
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
    /// Movie Seen selector Dialog
    /// </summary>
    public partial class MovieSeenSelectorDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        [Inject] private IMovieService MovieService { get; set; }
        private List<MyMovieSelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new List<int>();
        private bool IsLoading { get; set; } = false;
        private readonly List<MovieSeenUpdateModel> SaveList = new List<MovieSeenUpdateModel>();

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
            this.SelectedIndexList = this.List.Where(x => x.IsSeen).Select(x => x.Id).ToList();
        }

        private async Task GetSelectorList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.List = await this.MovieService.GetMySelectorList(true);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void Save()
        {
            if (await this.MovieService.UpdateSeenStatuses(this.SaveList))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void SwitchSeenFlag(MyMovieSelectorListDto movie)
        {
            movie.IsSeen = !movie.IsSeen;
            this.SaveList.Add(new MovieSeenUpdateModel { Id = movie.Id, Seen = movie.IsSeen });
            if (movie.IsSeen)
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