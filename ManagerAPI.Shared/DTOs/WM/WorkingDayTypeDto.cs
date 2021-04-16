namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working day type DTO
    /// </summary>
    public class WorkingDayTypeDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Day is active
        /// </summary>
        public bool DayIsActive { get; set; }
    }
}