using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EventManager.Client.Shared.Components.CSM
{
    /// <summary>
    /// Csomor Component
    /// </summary>
    public partial class CsomorComponent
    {
        /// <summary>
        /// Settings
        /// </summary>
        [Parameter]
        public GeneratorSettings Settings { get; set; }

        /// <summary>
        /// Table Type
        /// </summary>
        [Parameter]
        public CsomorType TableType { get; set; }

        /// <summary>
        /// Filter List
        /// </summary>
        [Parameter]
        public List<string> FilterList { get; set; }

        /// <summary>
        /// Table type changed event
        /// </summary>
        [Parameter]
        public EventCallback<CsomorType> TableTypeChanged { get; set; }

        /// <summary>
        /// Filter List changed event
        /// </summary>
        [Parameter]
        public EventCallback<List<string>> FilterListChanged { get; set; }

        private async void Changed(CsomorType element)
        {
            await this.TableTypeChanged.InvokeAsync(element);
        }

        private async void Changed(List<string> element)
        {
            await this.FilterListChanged.InvokeAsync(element);
        }
    }
}
