using ManagerAPI.Shared.Models.CSM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Generator Settings
    /// </summary>
    public class GeneratorSettings
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = "Untitled";

        /// <summary>
        /// Start
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Max Work Hour
        /// </summary>
        public int MaxWorkHour { get; set; } = 3;

        /// <summary>
        /// Min Rest Hour
        /// </summary>
        public int MinRestHour { get; set; } = 1;

        /// <summary>
        /// Persons
        /// </summary>
        public List<Person> Persons { get; set; }

        /// <summary>
        /// Works
        /// </summary>
        public List<Work> Works { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime? Creation { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Last Update
        /// </summary>
        public DateTime? LastUpdate { get; set; }

        /// <summary>
        /// Last Updater
        /// </summary>
        public string LastUpdater { get; set; }

        /// <summary>
        /// Is Shared
        /// </summary>
        public bool? IsShared { get; set; }

        /// <summary>
        /// Is Public
        /// </summary>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// has generated Csomor
        /// </summary>
        public bool HasGeneratedCsomor { get; set; }

        /// <summary>
        /// Last generation
        /// </summary>
        public DateTime? LastGeneration { get; set; }

        /// <summary>
        /// Shared with list
        /// </summary>
        public List<CsomorAccessDTO> SharedWith { get; set; }

        /// <summary>
        /// Init Generator Settings
        /// </summary>
        public GeneratorSettings() { }

        /// <summary>
        /// Init Person
        /// <param name="id">Id</param>
        /// <param name="model">Model</param>
        /// </summary>
        public GeneratorSettings(int? id, GeneratorSettingsModel model)
        {
            this.Id = id;
            this.Title = model.Title;
            this.Start = model.Start;
            this.Finish = model.Finish;
            this.MaxWorkHour = model.MaxWorkHour;
            this.MinRestHour = model.MinRestHour;
            this.Persons = model.Persons.Select(x => new Person(x)).ToList();
            this.Works = model.Works.Select(x => new Work(x)).ToList();
        }
    }
}