namespace ManagerAPI.Shared.Models.WM
{
    /// <summary>
    /// Working day type create or update model
    /// </summary>
    public class WorkingDayTypeModel
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Day Is Active
        /// </summary>
        public bool DayIsActive { get; set; }
    }
}