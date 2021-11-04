using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.CSM;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

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
        /// Removed event
        /// </summary>
        [Parameter]
        public EventCallback<string> Removed { get; set; }

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

        private List<WorkStatus> _statusList = new();

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            this.SetAvailableStatuses();
        }

        private void ChangeIsActiveStatus(WorkTableModel model, bool value)
        {
            model.IsActive = value;
            this.StateChanged.InvokeAsync();
        }

        private bool CheckRole(params CsomorRole[] roles)
        {
            return this.RoleChecker.Invoke(roles);
        }

        private void SetAvailableStatuses()
        {
            var list = new List<WorkStatus>();
            bool? lastStatus = null;

            Work.Tables.ForEach(table =>
            {
                bool val = table.IsActive;

                if (lastStatus is null)
                {
                    list.Add(new WorkStatus { Date = table.Date, Length = 1, Value = GetStatus(val) });
                    lastStatus = val;
                }
                else if (lastStatus == val)
                {
                    list[^1].Length++;
                }
                else
                {
                    list.Add(new WorkStatus { Date = table.Date, Length = 1, Value = GetStatus(val) });
                    lastStatus = val;
                }
            });

            this._statusList = list;
        }

        private string GetStatus(bool status)
        {
            return status ? "Active" : "Not Active";
        }
        
        private void Remove()
        {
            Removed.InvokeAsync(Work.Id);
        }

        class WorkStatus
        {
            public DateTime Date { get; set; }
            public string Value { get; set; }
            public int Length { get; set; }

            public string Interval
            {
                get
                {
                    return WriteHelper.HourInterval(Date, Length);
                }
            }
        }
    }
}
