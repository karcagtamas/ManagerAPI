using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Services;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;

namespace EventManager.Client.Shared.Navigators
{
    /// <summary>
    /// Main Navigator
    /// </summary>
    public partial class MainNavigator
    {
        /// <summary>
        /// Child
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        private IHelperService HelperService { get; set; }

        private string GetWorkingManagerUri()
        {
            return $"/wm/{DateHelper.DateToNumberDayString(DateTime.Now)}";
        }

        private string GetWorkingMonthStatUri()
        {
            return $"/wm/month/{HelperService.CurrentYear()}/{HelperService.CurrentMonth()}";
        }

        private string GetWorkingWeekStatUri()
        {
            return $"/wm/week/{DateHelper.DateToNumberDayString(HelperService.CurrentWeek())}";
        }
    }
}
