using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    /// <summary>
    /// Movie Data Page
    /// </summary>
    public partial class MovieDataPage
    {
        /// <summary>
        /// Movie Id
        /// </summary>
        [Parameter] public int Id { get; set; }
        private MyMovieDto Movie { get; set; }
        [Inject] private IMovieService MovieService { get; set; }
        [Inject] private IMovieCommentService MovieCommentService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }
        private bool IsLoading { get; set; }
        private string MovieImage { get; set; }
        private List<MovieCommentListDto> CommentList { get; set; }
        private string Comment { get; set; }
        private List<int> RateList { get; set; } = new List<int> { 1, 2, 3, 4, 5 };
        private bool CanEdit { get; set; }
        private bool CanDelete { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetMovie();
            await this.GetComments();
            this.CanEdit = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
            this.CanDelete = await this.Auth.HasRole("Administrator",
                "Status Library Administrator", "Root");
        }

        private async Task GetMovie()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.Movie = await this.MovieService.GetMy(this.Id);
            if (this.Movie.ImageData.Length != 0)
            {
                string base64 = Convert.ToBase64String(this.Movie.ImageData);
                this.MovieImage = $"data:image/gif;base64,{base64}";
            }

            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async Task GetComments()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.CommentList = await this.MovieCommentService.GetList(this.Id);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void OpenEditMovieDialog()
        {
            var parameters = new DialogParameters { { "MovieId", Id } };
            var dialog = DialogService.Show<MovieDialog>("Edit Movie", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovie();
            }
        }

        private async void OpenEditMovieImageDialog()
        {
            var parameters = new DialogParameters { { "MovieId", Id } };
            var dialog = DialogService.Show<MovieImageDialog>("Edit Image");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovie();
            }
        }

        private async void AddToMyMovies()
        {
            if (await this.MovieService.AddMovieToMyMovies(this.Id))
            {
                await this.GetMovie();
            }
        }

        private async void RemoveFromMyMovies()
        {
            if (await this.MovieService.RemoveMovieFromMyMovies(this.Id))
            {
                await this.GetMovie();
            }
        }

        private async void SetSeenStatus(bool status)
        {
            if (await this.MovieService.UpdateSeenStatuses(new List<MovieSeenUpdateModel>
                {new MovieSeenUpdateModel {Id = this.Movie.Id, Seen = status}}))
            {
                await this.GetMovie();
            }
        }

        private async void OpenEditMovieCategoriesDialog()
        {
            var parameters = new DialogParameters { { "MovieId", Id } };
            var dialog = DialogService.Show<MovieCategoryDialog>("Edit Categories", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Small
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovie();
            }
        }

        private async void SaveComment()
        {
            if (string.IsNullOrEmpty(this.Comment))
            {
                return;
            }

            if (!await this.MovieCommentService.Create(
                new MovieCommentModel { Comment = this.Comment, MovieId = this.Id }))
            {
                return;
            }

            this.Comment = "";
            await this.GetComments();
        }

        private async void UpdateRate(int rate)
        {
            if (await this.MovieService.UpdateRate(this.Id, new MovieRateModel { Rate = rate }))
            {
                await this.GetMovie();
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters {{"Input", new ConfirmDialogInput {
                Name = Movie.Title,
                Action = ConfirmType.Delete,
                DeleteFunction = async () => await MovieService.Delete(Movie.Id)
            }}};
            var dialog = DialogService.Show<ConfirmDialog>("Movie Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                this.Navigation.NavigateTo("movies");
            }
        }
    }
}