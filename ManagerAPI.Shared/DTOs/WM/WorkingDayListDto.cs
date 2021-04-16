using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working day list DTO
    /// </summary>
    public class WorkingDayListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        public DateTime Day { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Working fields
        /// </summary>
        public List<WorkingFieldListDto> WorkingFields { get; set; }
    }
}