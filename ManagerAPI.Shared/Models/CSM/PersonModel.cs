using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManagerAPI.Shared.Models.CSM
{
    /// <summary>
    /// Person Model
    /// </summary>
    public class PersonModel
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
        /// Person Tables
        /// </summary>
        public List<PersonTableModel> Tables { get; set; }

        /// <summary>
        /// Ignored Works
        /// </summary>
        public List<string> IgnoredWorks { get; set; }

        /// <summary>
        /// Is Ignored
        /// </summary>
        public bool IsIgnored { get; set; }

        /// <summary>
        /// Init Person Model
        /// </summary>
        public PersonModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tables = new List<PersonTableModel>();
            this.IgnoredWorks = new List<string>();
            this.IsIgnored = false;
        }

        /// <summary>
        /// Init Person Model from Name
        /// </summary>
        /// <param name="name">Name</param>
        public PersonModel(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tables = new List<PersonTableModel>();
            this.IgnoredWorks = new List<string>();
            this.IsIgnored = false;
            this.Name = name;
        }

        /// <summary>
        /// Ini Person Model from Person
        /// </summary>
        /// <param name="person">Person</param>
        public PersonModel(Person person)
        {
            this.Id = person.Id;
            this.Name = person.Name;
            this.Tables = person.Tables.Select(x => new PersonTableModel(x)).OrderBy(x => x.Date).ToList();
            this.IgnoredWorks = person.IgnoredWorks;
            this.IsIgnored = person.IsIgnored;
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
                this.Tables.Add(new PersonTableModel(s));
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
            this.Tables = new List<PersonTableModel>();

            this.SetTables(newStart, newFinish);

            foreach (var i in this.Tables)
            {
                var e = oldList.FirstOrDefault(x => DateHelper.CompareDates(x.Date, i.Date));
                if (e != null)
                {
                    i.IsAvailable = e.IsAvailable;
                }
            }
        }
    }
}
