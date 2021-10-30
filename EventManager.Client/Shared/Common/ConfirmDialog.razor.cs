// unset

using EventManager.Client.Enums;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Common
{
    /// <summary>
    /// Confirm Dialog
    /// </summary>
    public partial class ConfirmDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Dialog Input
        /// </summary>
        [Parameter]
        public ConfirmDialogInput Input { get; set; }

        private async void Confirm()
        {
            if (Input.DeleteFunction != null)
            {
                if (await Input.DeleteFunction())
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            } else
            {
                Dialog.Close(DialogResult.Ok(true));
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }

    /// <summary>
    /// Confirm Dialog Input
    /// </summary>
    public class ConfirmDialogInput
    {
        /// <summary>
        /// Confirm Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Confirm action
        /// </summary>
        public ConfirmType Action { get; set; }
        
        /// <summary>
        /// Delete function
        /// </summary>
        public Func<Task<bool>> DeleteFunction { get; set; }
    }
}