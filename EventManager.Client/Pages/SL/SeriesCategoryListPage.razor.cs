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
    /// Series Category List Page
    /// </summary>
    public partial class SeriesCategoryListPage
    {
        [Inject] private ISeriesCategoryService SeriesCategoryService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private List<SeriesCategoryDto> SeriesCategoryList { get; set; }
        private bool IsLoading { get; set; }
        private bool CanAdd { get; set; }

        private List<TableHeaderData<SeriesCategoryDto>> Header { get; set; } = new List<TableHeaderData<SeriesCategoryDto>>
        {
            new TableHeaderData<SeriesCategoryDto>("Name", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSeriesCategories();
            this.CanAdd = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
        }

        private async Task GetSeriesCategories()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.SeriesCategoryList = await this.SeriesCategoryService.GetAll<SeriesCategoryDto>("Name");
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void OpenAddSeriesCategoryDialog()
        {
            var parameters = new DialogParameters { { "SeriesCategoryId", null } };
            var dialog = DialogService.Show<SeriesCategoryEditDialog>("Add Series Category", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeriesCategories();
            }
        }

        private async void OpenEditSeriesCategoryDialog(SeriesCategoryDto category) 
        {
            var parameters = new DialogParameters { { "SeriesCategoryId", category.Id } };
            var dialog = DialogService.Show<SeriesCategoryEditDialog>("Edit Series Category", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeriesCategories();
            }
        }
    }
}