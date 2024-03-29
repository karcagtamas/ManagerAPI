﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Csomor person table
    /// </summary>
    public class CsomorPersonTable
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public string Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Person
        /// </summary>
        [Required]
        public string PersonId { get; set; }

        /// <summary>
        /// Is available
        /// </summary>
        [Required]
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        public string WorkId { get; set; }

        /// <summary>
        /// Person
        /// </summary>
        public virtual CsomorPerson Person { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        public virtual CsomorWork Work { get; set; }
    }
}