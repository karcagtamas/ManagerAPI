namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My book DTO
    /// </summary>
    public class MyBookDto : BookDto
    {
        /// <summary>
        /// Is mine
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// Is read
        /// </summary>
        public bool IsRead { get; set; }
    }
}