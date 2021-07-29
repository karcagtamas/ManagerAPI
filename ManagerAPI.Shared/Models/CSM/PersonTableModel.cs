using ManagerAPI.Shared.DTOs.CSM;
using System;

namespace ManagerAPI.Shared.Models.CSM
{
    /// <summary>
    /// Person Table Model
    /// </summary>
    public class PersonTableModel
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
        /// Is Available
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        public string WorkId { get; set; }

        /// <summary>
        /// Init Person Table Model
        /// </summary>
        public PersonTableModel() { }

        /// <summary>
        /// Init Person Table Model from Date
        /// </summary>
        /// <param name="date">Date</param>
        public PersonTableModel(DateTime date)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = date;
            this.IsAvailable = true;
            this.WorkId = null;
        }

        /// <summary>
        /// Init Person Table Model from Person Table
        /// </summary>
        /// <param name="table">Table</param>
        public PersonTableModel(PersonTable table)
        {
            this.Id = table.Id;
            this.Date = table.Date;
            this.IsAvailable = table.IsAvailable;
            this.WorkId = table.WorkId;
        }
    }
}
