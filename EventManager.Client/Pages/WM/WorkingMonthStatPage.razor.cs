using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.WM
{
    /// <summary>
    /// Working Month Stat Page
    /// </summary>
    public partial class WorkingMonthStatPage
    {
        /// <summary>
        /// Year
        /// </summary>
        [Parameter]
        public int Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        [Parameter]
        public int Month { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IWorkingFieldService FieldService { get; set; }

        private WorkingMonthStatDto MonthStat { get; set; }
        private bool IsLoading { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetMonthStat();
        }

        /// <inheritdoc />
        protected override async Task OnParametersSetAsync()
        {
            await this.GetMonthStat();
        }

        private async Task GetMonthStat()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.MonthStat = await this.FieldService.GetMonthStat(this.Year, this.Month);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void Redirect(bool direction)
        {
            if (direction)
            {
                int month = this.Month == 11 ? 0 : this.Month + 1;
                int year = month == 0 ? this.Year + 1 : this.Year;
                this.NavigationManager.NavigateTo($"/wm/month/{year}/{month}");
            }
            else
            {
                int month = this.Month == 0 ? 11 : this.Month - 1;
                int year = month == 11 ? this.Year - 1 : this.Year;
                this.NavigationManager.NavigateTo($"/wm/month/{year}/{month}");
            }
            this.StateHasChanged();
        }
    }
}