using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Book List DTO
    /// </summary>
    public class BookListDto : IIdentified
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Publish
        /// </summary>
        public DateTime? Publish { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }
    }
}