using System;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Csomor List
    /// </summary>
    public class CsomorListDTO
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
        /// Owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Has Csomor
        /// </summary>
        public bool HasCsomor { get; set; }

        /// <summary>
        /// Is Published
        /// </summary>        
        public bool IsPublished { get; set; }

        /// <summary>
        /// Is shared
        /// </summary>
        public bool IsShared { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation { get; set; }
    }
}
