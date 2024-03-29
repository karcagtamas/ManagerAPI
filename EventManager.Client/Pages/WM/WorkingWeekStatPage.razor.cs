﻿using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.WM
{
    /// <summary>
    /// Working Week Stat Page
    /// </summary>
    public partial class WorkingWeekStatPage
    {
        /// <summary>
        /// Week
        /// </summary>
        [Parameter] public DateTime Week { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IWorkingFieldService FieldService { get; set; }
        private WorkingWeekStatDto WeekStat { get; set; }
        private bool IsLoading { get; set; } = false;

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetWeekStat();
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            await this.GetWeekStat();
        }

        private async Task GetWeekStat()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.WeekStat = await this.FieldService.GetWeekStat(this.Week);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void Redirect(bool direction)
        {
            this.NavigationManager.NavigateTo(
                $"/wm/week/{DateHelper.DateToNumberDayString(this.Week.AddDays(direction ? 7 : -7))}");
            this.StateHasChanged();
        }
    }
}