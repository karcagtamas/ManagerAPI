using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Book Read Selector Dialog
    /// </summary>
    public partial class BookReadSelectorDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        [Inject] private IBookService BookService { get; set; }
        private List<MyBookSelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new();
        private bool IsLoading { get; set; }
        private readonly List<BookReadStatusModel> _saveList = new();

        private List<TableHeaderData<MyBookSelectorListDto>> Header { get; set; } = new()
        {
            new("Name", Alignment.Left),
            new("Publish", "Publish", (e) => DateHelper.DateToString((DateTime?)e), Alignment.Left),
            new("Author", Alignment.Left),
            new("Creator", Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSelectorList();
            this.SelectedIndexList = this.List.Where(x => x.IsRead).Select(x => x.Id).ToList();
        }

        private async Task GetSelectorList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.List = await this.BookService.GetMySelectorList(true);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void Save()
        {
            if (await this.BookService.UpdateReadStatuses(this._saveList))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void SwitchReadFlag(MyBookSelectorListDto book)
        {
            book.IsRead = !book.IsRead;
            this._saveList.Add(new BookReadStatusModel { Id = book.Id, Read = book.IsRead });
            if (book.IsRead)
            {
                this.SelectedIndexList.Add(book.Id);
            }
            else
            {
                this.SelectedIndexList.Remove(book.Id);
            }
        }
    }
}