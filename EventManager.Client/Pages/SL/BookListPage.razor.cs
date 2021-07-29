using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    /// <summary>
    /// Book List Page
    /// </summary>
    public partial class BookListPage
    {
        [Inject] private IBookService BookService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private List<BookListDto> BookList { get; set; }
        private bool IsLoading { get; set; }
        private bool CanAdd { get; set; }

        private List<TableHeaderData<BookListDto>> Header { get; set; } = new()
        {
            new("Name", true, Alignment.Left)
            { FooterRunnableData = (list) => list.Count.ToString() },
            new("Publish", "Publish", true, (e) => DateHelper.DateToString((DateTime?)e),
                Alignment.Right),
            new("Author", true, Alignment.Left),
            new("Creator", true, Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetBooks();
            this.CanAdd = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
        }

        private async Task GetBooks()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.BookList = await this.BookService.GetAll("Name");
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(BookListDto book)
        {
            this.Navigation.NavigateTo($"/books/{book.Id}");
        }

        private async void OpenAddBookDialog()
        {
            var parameters = new DialogParameters { { "BookId", null } };
            var dialog = DialogService.Show<BookDialog>("Add Book", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetBooks();
            }
        }
    }
}