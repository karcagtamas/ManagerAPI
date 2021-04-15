using ManagerAPI.Shared.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Task create or update model
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Task title
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(100, ErrorMessage = "Max length is 100")]
        public string Title { get; set; }

        /// <summary>
        /// Deadline
        /// </summary>

        [Required(ErrorMessage = "Field is required")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Description
        /// </summary>

        [Required(ErrorMessage = "Field is required")]
        public string Description { get; set; }

        /// <summary>
        /// Is Solved
        /// </summary>

        [Required] public bool IsSolved { get; set; }

        /// <summary>
        /// Init for mapper
        /// </summary>
        public TaskModel()
        {
        }

        /// <summary>
        /// Model from data object
        /// </summary>
        /// <param name="task">Task object</param>
        public TaskModel(TaskDto task)
        {
            this.Title = task.Title;
            this.Deadline = task.Deadline;
            this.Description = task.Description;
            this.IsSolved = task.IsSolved;
        }
    }
}