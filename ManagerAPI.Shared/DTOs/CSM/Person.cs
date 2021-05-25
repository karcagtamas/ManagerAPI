using ManagerAPI.Shared.Models.CSM;
using System.Collections.Generic;
using System.Linq;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person
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
        public List<PersonTable> Tables { get; set; }

        /// <summary>
        /// Ignored Works
        /// </summary>
        public List<string> IgnoredWorks { get; set; }

        /// <summary>
        /// Is Ignored
        /// </summary>
        public bool IsIgnored { get; set; }

        /// <summary>
        /// Hours
        /// </summary>
        public int Hours { get; set; } = 0;

        /// <summary>
        /// Init Person
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Init Person
        /// <param name="model">Model</param>
        /// </summary>
        public Person(PersonModel model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Tables = model.Tables.Select(x => new PersonTable(x)).ToList();
            this.IgnoredWorks = model.IgnoredWorks;
            this.IsIgnored = model.IsIgnored;
        }
    }
}