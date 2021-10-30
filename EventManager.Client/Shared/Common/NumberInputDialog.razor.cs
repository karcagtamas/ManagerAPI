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
    public partial class NumberInputDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        
        private int NumberInputValue { get; set; }

        /// <summary>
        /// Dialog Input
        /// </summary>
        [Parameter]
        public NumberInputDialogInput Input { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            NumberInputValue = Input.DefaultValue;
        }

        private void Confirm()
        {
            Dialog.Close(DialogResult.Ok(NumberInputValue));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }

    /// <summary>
    /// Confirm Dialog Input
    /// </summary>
    public class NumberInputDialogInput
    {
        /// <summary>
        /// Confirm Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Init value
        /// </summary>
        public int DefaultValue { get; set; }
    }
}