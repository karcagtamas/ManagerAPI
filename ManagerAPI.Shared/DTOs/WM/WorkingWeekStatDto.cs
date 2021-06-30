using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working week stat DTO
    /// </summary>
    public class WorkingWeekStatDto
    {
        /// <summary>
        /// Hour Sum
        /// </summary>
        public decimal HourSum { get; set; }

        /// <summary>
        /// Hour Avg
        /// </summary>
        public double HourAvg { get; set; }

        /// <summary>
        /// Active Days
        /// </summary>
        public int ActiveDays { get; set; }

        /// <summary>
        /// Work days
        /// </summary>
        public int WorkDays { get; set; }

        /// <summary>
        /// Counts
        /// </summary>
        public List<WorkingDayTypeCountDto> Counts { get; set; }

        /// <summary>
        /// Fields
        /// </summary>
        public List<WorkingFieldListDto> Fields { get; set; }
    }
}