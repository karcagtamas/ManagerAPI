﻿using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.WM
{
    public class WorkingFieldModel
    {
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(200, ErrorMessage = "Maximum length is 200")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public decimal Length { get; set; }
        public int WorkingDayId { get; set; }
    }
}
