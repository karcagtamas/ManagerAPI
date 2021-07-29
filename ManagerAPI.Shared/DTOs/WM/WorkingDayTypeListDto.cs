namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working day type list DTO
    /// </summary>
    public class WorkingDayTypeListDto
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