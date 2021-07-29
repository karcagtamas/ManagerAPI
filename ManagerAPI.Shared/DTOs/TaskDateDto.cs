using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Task date DTO
    /// </summary>
    public class TaskDateDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Out of range
        /// </summary>
        public bool OutOfRange { get; set; }

        /// <summary>
        /// All Solved
        /// </summary>
        public bool AllSolved { get; set; }

        /// <summary>
        /// Tasks
        /// </summary>
        public List<TaskDto> TaskList { get; set; }
    }
}