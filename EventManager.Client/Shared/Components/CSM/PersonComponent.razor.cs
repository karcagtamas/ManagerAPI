using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.CSM;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Client.Shared.Components.CSM
{
    /// <summary>
    /// Person Component
    /// </summary>
    public partial class PersonComponent
    {
        /// <summary>
        /// Person
        /// </summary>
        [Parameter]
        public PersonModel Person { get; set; }

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
        /// Work list
        /// </summary>
        [Parameter]
        public List<WorkModel> Works { get; set; }

        /// <summary>
        /// Is editable
        /// </summary>
        [Parameter]
        public bool IsEditable { get; set; }

        private bool IsEdit { get; set; } = false;
        private bool IsOpened { get; set; } = false;

        private List<PersonStatus> _statusList = new();
        private List<WorkStatus> _workStatusList = new();

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            this.SetAvailableStatuses();
            SetWorksStatuses();
        }

        private void ChangeIsAvailableStatus(PersonTableModel model, bool value)
        {
            model.IsAvailable = value;
            this.StateChanged.InvokeAsync();
        }

        private void ChangeIsIgnoredStatus(PersonModel model, bool value)
        {
            model.IsIgnored = value;
            this.StateChanged.InvokeAsync();
        }

        private bool CheckRole(params CsomorRole[] roles)
        {
            return this.RoleChecker.Invoke(roles);
        }

        private bool WorkIsIgnored(PersonModel person, WorkModel work)
        {
            return person.IgnoredWorks.Any(x => x == work.Id);
        }

        private void IgnoredWorkChange(PersonModel person, WorkModel work, bool value)
        {
            if (value)
            {
                if (person.IgnoredWorks.All(x => x != work.Id))
                {
                    person.IgnoredWorks.Add(work.Id);
                }
            }
            else
            {
                if (person.IgnoredWorks.Any(x => x == work.Id))
                {
                    person.IgnoredWorks.Remove(work.Id);
                }
            }
            this.StateChanged.InvokeAsync();
        }

        private void SetAvailableStatuses()
        {
            var list = new List<PersonStatus>();
            bool? lastStatus = null;

            Person.Tables.ForEach(table =>
            {
                bool val = table.IsAvailable;

                if (lastStatus is null)
                {
                    list.Add(new PersonStatus { Date = table.Date, Length = 1, Value = GetStatus(val) });
                    lastStatus = val;
                }
                else if (lastStatus == val)
                {
                    list[^1].Length++;
                }
                else
                {
                    list.Add(new PersonStatus { Date = table.Date, Length = 1, Value = GetStatus(val) });
                    lastStatus = val;
                }
            });

            this._statusList = list;
        }

        private void SetWorksStatuses()
        {
            var list = new List<WorkStatus>();
            var ignored = new WorkStatus { Name = "Ignored works" };
            ignored.Works = Works.Where(x => WorkIsIgnored(Person, x)).Select(x => x.Name).ToList();
            if (ignored.Works.Count > 0)
            {
                list.Add(ignored);
            }

            var notIgnored = new WorkStatus { Name = "Not ignored works" };
            notIgnored.Works = Works.Where(x => !WorkIsIgnored(Person, x)).Select(x => x.Name).ToList();
            if (notIgnored.Works.Count > 0)
            {
                list.Add(notIgnored);
            }

            _workStatusList = list;
        }

        private string GetStatus(bool status)
        {
            return status ? "Available" : "Not Available";
        }

        private void Remove()
        {
            Removed.InvokeAsync(Person.Id);
        }
    }

    class PersonStatus
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

    class WorkStatus
    {
        public string Name { get; set; }
        public List<string> Works { get; set; }

        public string WorkList 
        { 
            get
            {
                return string.Join(", ", Works);
            } 
        }
    }
}
