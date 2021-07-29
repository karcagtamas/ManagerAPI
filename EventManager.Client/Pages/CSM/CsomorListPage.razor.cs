﻿using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.CSM;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.CSM
{
    /// <summary>
    /// Csomor List Page
    /// </summary>
    public partial class CsomorListPage
    {
        [Inject]
        private NavigationManager Navigation { get; set; }

        [Inject]
        private IGeneratorService GeneratorService { get; set; }

        [Inject]
        private IAuthService Auth { get; set; }

        private List<CsomorListDTO> OwnedList { get; set; }
        private List<CsomorListDTO> SharedList { get; set; }
        private List<CsomorListDTO> PublicList { get; set; }
        private bool IsLoggedIn { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.IsLoggedIn = await this.Auth.IsLoggedIn();
            await this.GetList();
        }

        private async Task GetList()
        {
            if (this.IsLoggedIn)
            {
                await this.GetOwnedList();
                await this.GetSharedList();
            }
            await this.GetPublicList();
            this.StateHasChanged();
        }

        private async Task GetPublicList()
        {
            this.PublicList = await this.GeneratorService.GetPublicList();
        }

        private async Task GetSharedList()
        {
            this.SharedList = await this.GeneratorService.GetSharedList();
        }

        private async Task GetOwnedList()
        {
            this.OwnedList = await this.GeneratorService.GetOwnedList();
        }

        private bool HasAnyCsomor()
        {
            return ListHasAnyValue(PublicList) || ListHasAnyValue(SharedList) || ListHasAnyValue(OwnedList);
        }

        private bool ListHasAnyValue<T>(List<T> list)
        {
            return list is {Count: > 0};
        }
    }
}