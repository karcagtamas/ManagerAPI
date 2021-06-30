using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Book Dialog
    /// </summary>
    public partial class BookDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Book Id
        /// </summary>
        [Parameter]
        public int? BookId { get; set; }
        [Inject] private IBookService BookService { get; set; }
        private BookModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }
        private BookDto Book { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new BookModel
            {
                Name = "",
                Description = "",
                Author = "",
                Publish = null
            };

            this.Context = new EditContext(this.Model);

            if (BookId != null)
            {
                this.Book = await this.BookService.Get((int)BookId);
                this.Model = new BookModel(this.Book);
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }
        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (BookId == null)
                {
                    return;
                }

                if (await this.BookService.Update((int)BookId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.BookService.Create(this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }

            Dialog.Close(DialogResult.Ok(false));
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}