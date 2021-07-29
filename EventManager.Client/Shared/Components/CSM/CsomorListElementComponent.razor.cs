using ManagerAPI.Shared.DTOs.CSM;
using Microsoft.AspNetCore.Components;

namespace EventManager.Client.Shared.Components.CSM
{
    /// <summary>
    /// Csomor List Element Component
    /// </summary>
    public partial class CsomorListElementComponent
    {
        /// <summary>
        /// Csomor
        /// </summary>
        [Parameter]
        public CsomorListDTO Csomor { get; set; }

        /// <summary>
        /// Display Csomor owner
        /// </summary>
        [Parameter]
        public bool ShowOwner { get; set; } = true;

        /// <summary>
        /// Show published status
        /// </summary>
        [Parameter]
        public bool ShowIsPublished { get; set; } = true;

        /// <summary>
        /// Show shared status
        /// </summary>
        [Parameter]
        public bool ShowIsShared { get; set; } = true;

        [Inject]
        private NavigationManager NavigationManager { get; set; }
    }
}
