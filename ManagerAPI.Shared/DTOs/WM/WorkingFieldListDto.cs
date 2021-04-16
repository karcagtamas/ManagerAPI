namespace ManagerAPI.Shared.DTOs.WM
{
    /// <summary>
    /// Working field list DTO
    /// </summary>
    public class WorkingFieldListDto
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
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lenth
        /// </summary>
        public decimal Length { get; set; }
    }
}