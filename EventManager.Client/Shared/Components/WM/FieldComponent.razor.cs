using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EventManager.Client.Shared.Components.WM
{
    /// <summary>
    /// Field Component
    /// </summary>
    public partial class FieldComponent
    {
        /// <summary>
        /// Working Field
        /// </summary>
        [Parameter]
        public WorkingFieldListDto WorkingField { get; set; }

        /// <summary>
        /// Working Day Id
        /// </summary>
        [Parameter]
        public int WorkingDayId { get; set; }

        /// <summary>
        /// Is modifiable
        /// </summary>
        [Parameter]
        public bool IsModifiable { get; set; }

        /// <summary>
        /// Close callback
        /// </summary>
        [Parameter]
        public EventCallback Close { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private async void OpenUpdateFieldModal()
        {
            if (!this.IsModifiable)
            {
                return;
            }

            var parameters = new DialogParameters { { "WorkingDayId", this.WorkingDayId }, { "Id", this.WorkingField.Id } };

            var dialog = this.DialogService.Show<FieldModal>("Update Working field", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.Close.InvokeAsync(null);
            }
        }
    }
}