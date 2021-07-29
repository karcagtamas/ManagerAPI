namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My book list DTO
    /// </summary>
    public class MyBookListDto : BookListDto
    {
        /// <summary>
        /// Read
        /// </summary>
        public bool Read { get; set; }
    }
}