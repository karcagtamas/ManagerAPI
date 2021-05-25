using System;

namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// Master event DTO
    /// </summary>
    public class MasterEventDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is Locked
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Is Disabled
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Is Public
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Creator Id
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// Creator name
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Last Updater Id
        /// </summary>
        public string LastUpdaterId { get; set; }

        /// <summary>
        /// Last Updater name
        /// </summary>        
        public string LastUpdater { get; set; }

        /// <summary>
        /// Last Update
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}