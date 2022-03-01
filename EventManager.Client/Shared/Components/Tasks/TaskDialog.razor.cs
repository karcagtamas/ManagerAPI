using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Shared.Components.Tasks
{
    /// <summary>
    /// Task Dialog
    /// </summary>
    public partial class TaskDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        
        /// <summary>
        /// Task id for modification
        /// </summary>
        [Parameter]
        public int? TaskId { get; set; }

        [Inject]
        private ITaskService TaskService { get; set; }
        private EditContext Context { get; set; }
        private TaskModel Model { get; set; }
        private bool IsEdit { get; set; }
        private TaskDto? Task { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            this.Model = new TaskModel
            {
                Title = "",
                Description = "",
                Deadline = DateTime.Now
            };

            this.Context = new EditContext(this.Model);
            
            if (this.TaskId != null)
            {
                this.Task = await this.TaskService.Get<TaskDto>((int)TaskId);
                this.Model = new TaskModel
                {
                    Title = this.Task?.Title ?? string.Empty,
                    Description = this.Task?.Description ?? string.Empty,
                    Deadline = this.Task?.Deadline ?? DateTime.Now
                };
                this.IsEdit = true;
                this.Context = new EditContext(this.Model);
            }
        }

        private async void Save()
        {
            if (!Context.Validate()) return;

            if (this.IsEdit)
            {
                if (TaskId == null)
                {
                    return;
                }
                
                if (await this.TaskService.Update((int)TaskId, this.Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await this.TaskService.Create(this.Model))
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