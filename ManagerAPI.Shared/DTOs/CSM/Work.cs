using ManagerAPI.Shared.Models.CSM;
using System.Collections.Generic;
using System.Linq;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Work
    /// </summary>
    public class Work
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tables
        /// </summary>
        public List<WorkTable> Tables { get; set; }

        /// <summary>
        /// Init Work
        /// </summary>
        public Work() { }

        /// <summary>
        /// Init Work
        /// <param name="model">Model</param>
        /// </summary>
        public Work(WorkModel model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Tables = model.Tables.Select(x => new WorkTable(x)).ToList();
        }
    }
}