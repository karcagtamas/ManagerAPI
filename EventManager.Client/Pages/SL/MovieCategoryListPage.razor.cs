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
    /// Movie Category List Page
    /// </summary>
    public partial class MovieCategoryListPage
    {
        [Inject] private IMovieCategoryService MovieCategoryService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private List<MovieCategoryDto> MovieCategoryList { get; set; }
        private bool IsLoading { get; set; }
        private bool CanAdd { get; set; }

        private List<TableHeaderData<MovieCategoryDto>> Header { get; set; } = new List<TableHeaderData<MovieCategoryDto>>
        {
            new TableHeaderData<MovieCategoryDto>("Name", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetMovieCategories();
            this.CanAdd = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
        }

        private async Task GetMovieCategories()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.MovieCategoryList = await this.MovieCategoryService.GetAll("Name");
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void OpenAddMovieCategoryDialog()
        {
            var parameters = new DialogParameters { { "MovieCategoryId", null } };
            var dialog = DialogService.Show<MovieCategoryEditDialog>("Add Movie Category", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovieCategories();
            }
        }

        private async void OpenEditMovieCategoryDialog(MovieCategoryDto category) 
        {
            var parameters = new DialogParameters { { "MovieCategoryId", category.Id } };
            var dialog = DialogService.Show<MovieCategoryEditDialog>("Edit Movie Category", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetMovieCategories();
            }
        }
    }
}