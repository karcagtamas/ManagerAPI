namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working day stat DTO
    /// </summary>
    public class WorkingDayStatDto
    {
        /// <summary>
        /// Sum Mints
        /// </summary>
        public int SumMinutes { get; set; }

        /// <summary>
        /// Is enough
        /// </summary>
        public bool IsEnough { get; set; }

        /// <summary>
        /// Is optimal
        /// </summary>
        public bool IsOptimal { get; set; }

        /// <summary>
        /// Is a lot
        /// </summary>
        public bool IsALot { get; set; }

        /// <summary>
        /// Is active
        /// </summary>
        public bool IsActive { get; set; }
    }
}