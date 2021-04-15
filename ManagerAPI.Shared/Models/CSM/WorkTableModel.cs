using ManagerAPI.Shared.DTOs.CSM;
using System;

namespace ManagerAPI.Shared.Models.CSM
{   
    /// <summary>
    /// Work Table Model
    /// </summary>
    public class WorkTableModel
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
        /// Person
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Init Work Table Model
        /// </summary>
        public WorkTableModel() { }

        /// <summary>
        /// Init Work Table Model from Date
        /// </summary>
        /// <param name="date">date</param>
        public WorkTableModel(DateTime date)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = date;
            this.IsActive = true;
            this.PersonId = null;
        }

        /// <summary>
        /// Init Work Table Model from Work Table
        /// </summary>
        /// <param name="table">Table</param>
        public WorkTableModel(WorkTable table)
        {
            this.Id = table.Id;
            this.Date = table.Date;
            this.IsActive = table.IsActive;
            this.PersonId = table.PersonId;
        }
    }
}
