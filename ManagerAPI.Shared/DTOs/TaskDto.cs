using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Task DTO
    /// </summary>
    public class TaskDto
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
        /// Deadline
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Is Solved
        /// </summary>
        public bool IsSolved { get; set; }
    }
}