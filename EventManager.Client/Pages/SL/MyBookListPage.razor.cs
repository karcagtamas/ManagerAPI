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
    /// My Book List Page
    /// </summary>
    public partial class MyBookListPage
    {
        [Inject] private IBookService BookService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        private List<MyBookListDto> BookList { get; set; }
        private bool IsLoading { get; set; }

        private List<TableHeaderData<MyBookListDto>> Header { get; set; } = new()
        {
            new TableHeaderData<MyBookListDto>("Name", true, Alignment.Left)
                {FooterRunnableData = (list) => list.Count.ToString()},
            new TableHeaderData<MyBookListDto>("Publish", "Publish", true, (e) => DateHelper.DateToString((DateTime?) e),
                Alignment.Right),
            new TableHeaderData<MyBookListDto>("Author", true, Alignment.Left),
            new TableHeaderData<MyBookListDto>("Creator", true, Alignment.Left),
            new TableHeaderData<MyBookListDto>("Read", "Read", true, (e) => (bool) e ? "Read" : "Not read", Alignment.Center)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetBooks();
        }

        private async Task GetBooks()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.BookList = await this.BookService.GetMyList();
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private void RedirectToData(MyBookListDto book)
        {
            this.Navigation.NavigateTo($"/books/{book.Id}");
        }

        private async void OpenEditMyBooksDialog()
        {
            var parameters = new DialogParameters();
            var dialog = DialogService.Show<BookSelectorDialog>("Edit My Books", parameters);
            var result = await dialog.Result;
            
            if (!result.Cancelled)
            {
                await this.GetBooks();
            }
        }

        private async void OpenEditReadBooksDialog()
        {
            var parameters = new DialogParameters();
            var dialog = DialogService.Show<BookReadSelectorDialog>("Edit Read Books", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetBooks();
            }
        }
    }
}