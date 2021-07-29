using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;
using Microsoft.AspNetCore.Components;
using System;

namespace EventManager.Client.Shared.Components.CSM
{
    /// <summary>
    /// Work Component
    /// </summary>
    public partial class WorkComponent
    {
        /// <summary>
        /// Work
        /// </summary>
        [Parameter]
        public WorkModel Work { get; set; }

        /// <summary>
        /// State changed event
        /// </summary>
        [Parameter]
        public EventCallback StateChanged { get; set; }

        /// <summary>
        /// Role checker
        /// </summary>
        [Parameter]
        public Func<CsomorRole[], bool> RoleChecker { get; set; }

        /// <summary>
        /// Is editable
        /// </summary>
        [Parameter]
        public bool IsEditable { get; set; } = false;

        private bool IsEdit { get; set; } = false;
        private bool IsOpened { get; set; } = false;

        private void ChangeIsActiveStatus(WorkTableModel model, bool value)
        {
            model.IsActive = value;
            this.StateChanged.InvokeAsync();
        }

        private bool CheckRole(params CsomorRole[] roles)
        {
            return this.RoleChecker.Invoke(roles);
        }
    }
}
