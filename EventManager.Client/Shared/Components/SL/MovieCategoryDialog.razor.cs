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
    /// Movie category Dialog
    /// </summary>
    public partial class MovieCategoryDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Movie Id
        /// </summary>
        [Parameter]
        public int MovieId { get; set; }

        [Inject] private IMovieService MovieService { get; set; }
        [Inject] private IMovieCategoryService MovieCategoryService { get; set; }
        private List<MovieCategorySelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new List<int>();
        private bool IsLoading { get; set; } = false;

        private List<TableHeaderData<MovieCategorySelectorListDto>> Header { get; set; } = new List<TableHeaderData<MovieCategorySelectorListDto>>
        {
            new TableHeaderData<MovieCategorySelectorListDto>("Name", "Category", Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSelectorList();
            this.SelectedIndexList = this.List.Where(x => x.IsSelected).Select(x => x.Id).ToList();
        }

        private async Task GetSelectorList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.List = await this.MovieCategoryService.GetSelectorList(this.MovieId);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void Save()
        {
            var indexList = this.List.Where(x => x.IsSelected).Select(x => x.Id).ToList();

            if (await this.MovieService.UpdateCategories(this.MovieId, new MovieCategoryUpdateModel { Ids = indexList }))
            {
                Dialog.Close(DialogResult.Ok(true));
            }
        }

        private void SwitchSelectedFlag(MovieCategorySelectorListDto category)
        {
            category.IsSelected = !category.IsSelected;
            if (category.IsSelected)
            {
                this.SelectedIndexList.Add(category.Id);
            }
            else
            {
                this.SelectedIndexList.Remove(category.Id);
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}