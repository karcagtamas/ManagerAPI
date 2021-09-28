using EventManager.Client.Enums;
using EventManager.Client.Models;
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
    /// Series Data Page
    /// </summary>
    public partial class SeriesDataPage
    {
        /// <summary>
        /// Series Id
        /// </summary>
        [Parameter]
        public int Id { get; set; }

        private MySeriesDto Series { get; set; }
        [Inject] private ISeriesService SeriesService { get; set; }
        [Inject] private ISeriesCommentService SeriesCommentService { get; set; }
        [Inject] private ISeasonService SeasonService { get; set; }
        [Inject] private IEpisodeService EpisodeService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }
        private bool IsLoading { get; set; }
        private string SeriesImage { get; set; }
        private List<SeriesCommentListDto> CommentList { get; set; }
        private string Comment { get; set; }

        private List<int> RateList { get; set; } = new()
        {
            1,
            2,
            3,
            4,
            5
        };

        private bool CanAddOrEdit { get; set; }
        private bool CanDelete { get; set; }

        private int ActiveTab { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSeries();
            await this.GetComments();
            this.CanAddOrEdit = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
            this.CanDelete = await this.Auth.HasRole("Administrator",
                "Status Library Administrator", "Root");
        }

        private async Task GetSeries()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.Series = await this.SeriesService.GetMy(this.Id);
            if (this.Series.ImageData.Length != 0)
            {
                string base64 = Convert.ToBase64String(this.Series.ImageData);
                this.SeriesImage = $"data:image/gif;base64,{base64}";
            }

            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async Task GetComments()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.CommentList = await this.SeriesCommentService.GetList(this.Id);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void OpenEditSeriesDialog()
        {
            var parameters = new DialogParameters {{"SeriesId", Id}};
            var dialog = DialogService.Show<SeriesDialog>("Edit Series", parameters,
                new DialogOptions {FullWidth = true, MaxWidth = MaxWidth.Medium});
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeries();
            }
        }

        private async void AddToMySeriesList()
        {
            if (await this.SeriesService.AddSeriesToMySeries(this.Id))
            {
                await this.GetSeries();
            }
        }

        private async void RemoveFromMySeriesList()
        {
            if (await this.SeriesService.RemoveSeriesFromMySeries(this.Id))
            {
                await this.GetSeries();
            }
        }

        private async void SetSeenStatus(bool status)
        {
            if (await this.SeriesService.UpdateSeenStatus(
                new SeriesSeenStatusModel {Id = this.Series.Id, Seen = status}))
            {
                await this.GetSeries();
            }
        }

        private async void AddIncrementedSeason()
        {
            if (await this.SeasonService.AddIncremented(this.Series.Id, 1))
            {
                await this.GetSeries();
            }
        }

        private async void AddMultipleIncrementedSeason()
        {
            var parameters = new DialogParameters {{"Name", "season creation"}, {"DefaultValue", 2}};
            var dialog = DialogService.Show<NumberInputDialog>("Number Input", parameters,
                new DialogOptions {FullWidth = true, MaxWidth = MaxWidth.Small});
            var result = await dialog.Result;
            
            if (await this.SeasonService.AddIncremented(this.Series.Id, (int)result.Data))
            {
                await this.GetSeries();
            }
        }

        private async void OpenEditSeriesCategoriesDialog()
        {
            var parameters = new DialogParameters {{"SeriesId", Id}};
            var dialog = DialogService.Show<SeriesCategoryDialog>("Edit Categories", parameters,
                new DialogOptions {FullWidth = true, MaxWidth = MaxWidth.Small});
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeries();
            }
        }

        private async void SaveComment()
        {
            if (string.IsNullOrEmpty(this.Comment))
            {
                return;
            }

            if (!await this.SeriesCommentService.Create(new SeriesCommentModel
            {
                Comment = this.Comment, SeriesId = this.Id
            }))
            {
                return;
            }

            this.Comment = "";
            await this.GetComments();
        }

        private async void UpdateRate(int rate)
        {
            if (await this.SeriesService.UpdateRate(this.Id, new SeriesRateModel {Rate = rate}))
            {
                await this.GetSeries();
            }
        }

        private async void OpenEditSeriesImageDialog()
        {
            var parameters = new DialogParameters {{"SeriesId", Id}};
            var dialog = DialogService.Show<SeriesImageDialog>("Edit Image", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetSeries();
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = Series.Title,
                        Action = ConfirmType.Delete,
                        DeleteFunction = async () => await SeriesService.Delete(Series.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Series Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                this.Navigation.NavigateTo("series");
            }
        }

        private async void Changed()
        {
            await this.GetSeries();
        }
    }
}