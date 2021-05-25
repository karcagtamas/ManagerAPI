using ManagerAPI.Shared.Models.CSM;
using System;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Person Table
    /// </summary>
    public class PersonTable
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
        /// Work Id
        /// </summary>
        public string WorkId { get; set; }

        /// <summary>
        /// Init Person Table
        /// </summary>
        public PersonTable() { }

        /// <summary>
        /// Init Person Table
        /// <param name="model">Model</param>
        /// </summary>
        public PersonTable(PersonTableModel model)
        {
            this.Id = model.Id;
            this.Date = model.Date;
            this.IsAvailable = model.IsAvailable;
            this.WorkId = null;
        }
    }
}