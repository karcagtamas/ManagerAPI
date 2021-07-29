using ManagerAPI.Shared.Enums;
using System.Collections.Generic;

namespace ManagerAPI.Shared.Models.CSM
{
    /// <summary>
    /// Export Settings Model
    /// </summary>
    public class ExportSettingsModel
    {
        /// <summary>
        /// Export type
        /// </summary>
        public CsomorType Type { get; set; }

        /// <summary>
        /// Filter List
        /// </summary>
        public List<string> FilterList { get; set; }
    }
}
