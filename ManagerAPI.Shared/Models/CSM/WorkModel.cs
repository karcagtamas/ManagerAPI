using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManagerAPI.Shared.Models.CSM
{
    /// <summary>
    /// Work Model
    /// </summary>
    public class WorkModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>

        [Required(ErrorMessage = "Field is required")]
        [MaxLength(120, ErrorMessage = "Max length is 120")]
        public string Name { get; set; }

        /// <summary>
        /// Work Tables
        /// </summary>
        public List<WorkTableModel> Tables { get; set; }

        /// <summary>
        /// Init Work Model
        /// </summary>
        public WorkModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tables = new List<WorkTableModel>();
        }

        /// <summary>
        /// Init Work Model
        /// </summary>
        /// <param name="name">Name</param>
        public WorkModel(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tables = new List<WorkTableModel>();
            this.Name = name;
        }

        /// <summary>
        /// Init Work Model
        /// </summary>
        /// <param name="work">Work</param>
        public WorkModel(Work work)
        {
            this.Id = work.Id;
            this.Name = work.Name;
            this.Tables = work.Tables.Select(x => new WorkTableModel(x)).OrderBy(x => x.Date).ToList();
        }

        /// <summary>
        /// Set tables by date interval
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="finish">End</param>
        public void SetTables(DateTime start, DateTime finish)
        {
            var s = start;
            while (s < finish)
            {
                this.Tables.Add(new WorkTableModel(s));
                s = s.AddHours(1);
            }
        }

        /// <summary>
        /// Update table by date interval
        /// </summary>
        /// <param name="newStart">Start</param>
        /// <param name="newFinish">End</param>
        public void UpdateTable(DateTime newStart, DateTime newFinish)
        {
            var oldList = this.Tables;
            this.Tables = new List<WorkTableModel>();

            this.SetTables(newStart, newFinish);

            foreach (var i in this.Tables)
            {
                var e = oldList.FirstOrDefault(x => DateHelper.CompareDates(x.Date, i.Date));
                if (e != null)
                {
                    i.IsActive = e.IsActive;
                }
            }
        }
    }
}
