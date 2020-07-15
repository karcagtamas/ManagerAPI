﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Models.Entities.MC
{
    public class Movie {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength (150)]
        public string Title { get; set; }

        [MaxLength (999)]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [Required]
        public string LastUpdaterId { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }
        public virtual User Creator { get; set; }
        public virtual User LastUpdater { get; set; }
        public virtual ICollection<UserMovie> ConnectedUsers { get; set; }
    }
}
