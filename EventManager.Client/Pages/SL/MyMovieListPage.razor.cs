using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    /// <summary>
    /// My Movie List Page
    /// </summary>
    public partial class MyMovieListPage
    {
        [Inject] private IMovieService MovieService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        private List<MyMovieListDto> MovieList { get; set; }
        private bool IsLoading { get; set; }

        private List<TableHeaderData<MyMovieListDto>> Header { get; set; } = new List<TableHeaderData<MyMovieListDto>>
        {
            new TableHeaderData<MyMovieListDto>("Title", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
            new TableHeaderData<MyMovieListDto>("ReleaseYear", "Release Year", true, (e) => ((int) e).ToString(), Alignment.Right),
            new TableHeaderData<MyMovieListDto>("Creator", true, Alignment.Left),
            new TableHeaderData<MyMovieListDto>("IsSeen", "Is Seen", true, (e) => ((bool) e) ? "Seen" : "Not seen", Alignment.Center)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetMovies();
        }

        private async Task GetMovies()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.MovieList = await this.MovieService.GetMyList();
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(MyMovieListDto book)
        {
            this.Navigation.NavigateTo($"/movies/{book.Id}");
        }

        private async void OpenEditMyMoviesDialog()
        {
            var parameters = new DialogParameters();
            var dialog = DialogService.Show<MovieSelectorDialog>("Edit My Movies", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Small
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovies();
            }
        }

        private async void OpenEditSeenMoviesDialog()
        {
            var parameters = new DialogParameters();
            var dialog = DialogService.Show<MovieSeenSelectorDialog>("Edit Seen Books", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Small
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovies();
            }
        }
    }
}