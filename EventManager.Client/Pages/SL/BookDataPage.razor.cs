using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using EventManager.Client.Shared.Components.SL;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.SL
{
    /// <summary>
    /// Book Data Page
    /// </summary>
    public partial class BookDataPage
    {
        /// <summary>
        /// Book Id
        /// </summary>
        [Parameter] public int Id { get; set; }
        private MyBookDto? Book { get; set; }
        [Inject] private IBookService BookService { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private IAuthService Auth { get; set; }

        private bool IsLoading { get; set; }
        private bool CanEdit { get; set; }
        private bool CanDelete { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetBook();
            this.CanEdit = await this.Auth.HasRole("Administrator", "Status Library Moderator",
                "Status Library Administrator", "Root");
            this.CanDelete = await this.Auth.HasRole("Administrator",
                "Status Library Administrator", "Root");
        }

        private async Task GetBook()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.Book = await this.BookService.GetMy(this.Id);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void OpenEditBookDialog()
        {
            var parameters = new DialogParameters { { "BookId", this.Id } };
            var dialog = DialogService.Show<BookDialog>("Edit Book", parameters, new DialogOptions
            {
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetBook();
            }
        }

        private async void AddToMyBooks()
        {
            if (await this.BookService.AddBookToMyBooks(this.Id))
            {
                await this.GetBook();
            }
        }

        private async void RemoveFromMyBooks()
        {
            if (await this.BookService.RemoveBookFromMyBooks(this.Id))
            {
                await this.GetBook();
            }
        }

        private async void SetReadStatus(bool status)
        {
            if (await this.BookService.UpdateReadStatuses(new List<BookReadStatusModel>
                {new BookReadStatusModel {Id = this.Book.Id, Read = status}}))
            {
                await this.GetBook();
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters {{"Input", new ConfirmDialogInput
            {
                Name = Book.Name,
                Action = ConfirmType.Delete,
                DeleteFunction = async () => await BookService.Delete(Book.Id)
            }}};
            var dialog = DialogService.Show<ConfirmDialog>("Book Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                this.Navigation.NavigateTo("books");
            }
        }
    }
}