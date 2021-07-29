using EventManager.Client.Enums;
using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models;
using ManagerAPI.Shared.Models.WM;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.WM
{
    /// <summary>
    /// Field Modal
    /// </summary>
    public partial class FieldModal
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject] private IWorkingFieldService WorkingFieldService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private WorkingFieldModel Model { get; set; }
        private EditContext Context { get; set; }
        private bool IsEdit { get; set; }

        /// <summary>
        /// Field Id
        /// </summary>
        [Parameter]
        public int Id { get; set; }

        /// <summary>
        /// Working day Id
        /// </summary>
        [Parameter]
        public int WorkingDayId { get; set; }
        private WorkingFieldDto Field { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new WorkingFieldModel
            {
                Title = "",
                Description = "",
                Length = 1
            };

            this.Context = new EditContext(this.Model);

            if (this.Id != 0)
            {
                this.Field = await this.WorkingFieldService.Get(this.Id);
                this.Model = new WorkingFieldModel
                {
                    Title = this.Field.Title,
                    Description = this.Field.Description,
                    Length = this.Field.Length
                };
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = Field.Title,
                        Action = ConfirmType.Delete,
                        DeleteFunction = async () => await this.WorkingFieldService.Delete(this.Id)
                    }
                }
            };

            var dialog = DialogService.Show<ConfirmDialog>("Delete Confirm", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                Dialog.Close(DialogResult.Ok(true));
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;
            this.Model.WorkingDayId = this.WorkingDayId;

            if (this.IsEdit)
            {
                if (await this.WorkingFieldService.Update(this.Id, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.WorkingFieldService.Create(this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}