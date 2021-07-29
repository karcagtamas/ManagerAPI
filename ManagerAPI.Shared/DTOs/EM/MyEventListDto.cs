using System;

namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// My event list DTO
    /// </summary>
    public class MyEventListDto
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
        /// Members
        /// </summary>
        public int Members { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }
    }
}