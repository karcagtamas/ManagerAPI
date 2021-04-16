namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My book selector list DTO
    /// </summary>
    public class MyBookSelectorListDto : BookListDto
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