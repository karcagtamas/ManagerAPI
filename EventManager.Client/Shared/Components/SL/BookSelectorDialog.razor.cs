using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services;
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
    /// Book Selector Dialog
    /// </summary>
    public partial class BookSelectorDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        [Inject] private IBookService BookService { get; set; }
        [Inject] private IModalService ModalService { get; set; }
        private int FormId { get; set; }
        private List<MyBookSelectorListDto> List { get; set; }
        private List<int> SelectedIndexList { get; set; } = new();
        private bool IsLoading { get; set; }

        private List<TableHeaderData<MyBookSelectorListDto>> Header { get; set; } = new()
        {
            new("Name", Alignment.Left),
            new("Publish", "Publish", (e) => DateHelper.DateToString((DateTime?) e), Alignment.Left),
            new("Author", Alignment.Left),
            new("Creator", Alignment.Left)
        };

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetSelectorList();
            this.SelectedIndexList = this.List.Where(x => x.IsMine).Select(x => x.Id).ToList();
        }

        private async Task GetSelectorList()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.List = await this.BookService.GetMySelectorList(false);
            this.IsLoading = false;
            this.StateHasChanged();
        }
        
        private async void Save()
        {
            var indexList = this.List.Where(x => x.IsMine).Select(x => x.Id).ToList();

            if (await this.BookService.UpdateMyBooks(new MyBookModel { Ids = indexList }))
            {
                Dialog.Close(DialogResult.Ok(true));
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private void SwitchMineFlag(MyBookSelectorListDto book)
        {
            book.IsMine = !book.IsMine;
            if (book.IsMine)
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