﻿using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    public class MovieCommentModel
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}