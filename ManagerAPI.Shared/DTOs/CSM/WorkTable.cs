using ManagerAPI.Shared.Models.CSM;
using System;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Work Table
    /// </summary>
    public class WorkTable
    {

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Person Id
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Init Work Table
        /// </summary>
        public WorkTable() { }

        /// <summary>
        /// Init Work Table
        /// <param name="model">Model</param>
        /// </summary>
        public WorkTable(WorkTableModel model)
        {
            this.Id = model.Id;
            this.Date = model.Date;
            this.IsActive = model.IsActive;
            this.PersonId = null;
        }
    }
}