using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.WM;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.WM;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.WM
{
    /// <summary>
    /// Working Manager Page
    /// </summary>
    public partial class WorkingManagerPage
    {
        /// <summary>
        /// Date
        /// </summary>
        [Parameter]
        public DateTime Date { get; set; }

        [Inject]
        private IWorkingDayService WorkingDayService { get; set; }

        [Inject]
        private IWorkingDayTypeService WorkingDayTypeService { get; set; }

        [Inject]
        private IHelperService HelperService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private WorkingDayModel WorkingDay { get; set; }
        private int? WorkingDayId { get; set; }
        private bool IsLoading { get; set; }
        private List<WorkingDayTypeListDto> WorkingDayTypes { get; set; }
        private List<WorkingFieldListDto> WorkingFields { get; set; }
        private WorkingDayStatDto WorkingDayStat { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetWorkingDay();
            await this.GetWorkingDayTypes();
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            await this.GetWorkingDay();
        }

        private async Task GetWorkingDay()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            var workingDay = await this.WorkingDayService.Get(this.Date);
            this.WorkingDay = workingDay != null ? new WorkingDayModel
            {
                Type = workingDay.Type,
                Date = workingDay.Day
            } : null;
            this.WorkingDayId = workingDay?.Id;
            this.WorkingFields = workingDay?.WorkingFields;
            this.WorkingDayStat =
                this.WorkingDayId == null ? null : await this.WorkingDayService.Stat((int)this.WorkingDayId);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async Task GetWorkingDayTypes()
        {
            this.WorkingDayTypes = await this.WorkingDayTypeService.GetAll("Title");
        }

        private void Redirect(bool direction)
        {
            this.NavigationManager.NavigateTo($"/wm/{DateHelper.DateToNumberDayString(this.Date.AddDays(direction ? 1 : -1))}");
        }

        private async Task InitWorkingDay()
        {
            var workingDay = new WorkingDayModel
            {
                Date = this.Date,
                Type = 1
            };

            if (await this.WorkingDayService.Create(workingDay))
            {
                await this.GetWorkingDay();
            }
        }

        private async Task Save()
        {
            if (this.WorkingDay != null && this.WorkingDayId != null && await this.WorkingDayService.Update((int)this.WorkingDayId, this.WorkingDay))
            {
                await this.GetWorkingDay();
            }
        }

        private async void OpenAddFieldModal()
        {
            if (this.WorkingDayId != null)
            {
                var parameters = new DialogParameters { { "WorkingDayId", (int)WorkingDayId } };
                var dialog = DialogService.Show<FieldModal>("Create Working field", parameters, new DialogOptions
                {
                    FullWidth = true,
                    MaxWidth = MaxWidth.Small
                });
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    await this.GetWorkingDay();
                }
            }
        }
    }
}