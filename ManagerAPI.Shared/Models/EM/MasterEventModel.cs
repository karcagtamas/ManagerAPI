using ManagerAPI.Shared.DTOs.EM;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.EM
{
    /// <summary>
    /// Master event create or update DTO
    /// </summary>
    public class MasterEventModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required] [MaxLength(256)] public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Is Locked
        /// </summary>
        [Required] public bool IsLocked { get; set; }

        /// <summary>
        /// Is Disabled
        /// </summary>
        [Required] public bool IsDisabled { get; set; }

        /// <summary>
        /// Is Public
        /// </summary>
        [Required] public bool IsPublic { get; set; }

        /// <summary>
        /// Empty init
        /// </summary>
        public MasterEventModel()
        {
        }

        /// <summary>
        /// Model from event data object
        /// </summary>
        /// <param name="masterEvent">Master event data object</param>
        public MasterEventModel(MasterEventDto masterEvent)
        {
            this.Id = masterEvent.Id;
            this.Title = masterEvent.Title;
            this.Description = masterEvent.Description;
            this.StartDate = masterEvent.StartDate;
            this.EndDate = masterEvent.EndDate;
            this.IsLocked = masterEvent.IsLocked;
            this.IsDisabled = masterEvent.IsDisabled;
            this.IsPublic = masterEvent.IsPublic;
        }
    }
}