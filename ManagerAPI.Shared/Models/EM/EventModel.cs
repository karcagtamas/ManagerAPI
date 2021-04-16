﻿using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.EM
{
    /// <summary>
    /// Event create or update model
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(256, ErrorMessage = "Title's max length is 256")]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}