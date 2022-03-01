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
    /// Movie List Page
    /// </summary>
    public partial class MovieListPage
    {
        [Inject] private IMovieService MovieService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private List<MovieListDto> MovieList { get; set; }
        private bool IsLoading { get; set; }
        private bool CanAdd { get; set; }

        private List<TableHeaderData<MovieListDto>> Header { get; set; } = new List<TableHeaderData<MovieListDto>>
        {
            new TableHeaderData<MovieListDto>("Title", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
            new TableHeaderData<MovieListDto>("ReleaseYear", "Release Year", true, (e) => ((int) e).ToString(),
                Alignment.Right),
            new TableHeaderData<MovieListDto>("Creator", true, Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetMovies();
            this.CanAdd = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
        }

        private async Task GetMovies()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.MovieList = await this.MovieService.GetAll<MovieListDto>("Title");
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(MovieListDto movie)
        {
            this.Navigation.NavigateTo($"/movies/{movie.Id}");
        }

        private async void OpenAddMovieDialog()
        {
            var parameters = new DialogParameters { { "MovieId", null } };
            var dialog = DialogService.Show<MovieDialog>("Add Movie", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovies();
            }
        }
    }
}