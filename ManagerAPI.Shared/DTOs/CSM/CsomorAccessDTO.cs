using System;

namespace ManagerAPI.Shared.DTOs.CSM
{
    /// <summary>
    /// Csomor Access
    /// </summary>
    public class CsomorAccessDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// E-mail address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Has write access
        /// </summary>
        public bool HasWriteAccess { get; set; }

        /// <summary>
        /// Shared date
        /// </summary>
        public DateTime SharedOn { get; set; }
    }
}
