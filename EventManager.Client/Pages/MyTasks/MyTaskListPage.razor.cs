using EventManager.Client.Enums;
using EventManager.Client.Services.Interfaces;
using EventManager.Client.Shared.Common;
using EventManager.Client.Shared.Components.Tasks;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Pages.MyTasks
{
    /// <summary>
    /// My Task List page
    /// </summary>
    public partial class MyTaskListPage
    {
        [Inject] private ITaskService TaskService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private List<TaskDateDto> TaskList { get; set; }
        private bool IsLoading { get; set; }
        private bool? IsSolvedSelectorValue { get; set; } = false;

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetTasks();
        }

        private async Task GetTasks()
        {
            this.IsLoading = true;
            this.StateHasChanged();
            this.TaskList = await this.TaskService.GetDate(this.IsSolvedSelectorValue);
            this.IsLoading = false;
            this.StateHasChanged();
        }

        private async void IsSolvedChanged(bool newValue, int taskId, TaskDateDto group)
        {
            var task = this.TaskList.SelectMany(x => x.TaskList).FirstOrDefault(x => x.Id == taskId);

            if (task == null)
            {
                return;
            }

            var taskData = await this.TaskService.Get<TaskDto>(taskId);
            if (taskData == null)
            {
                return;
            }

            taskData.IsSolved = newValue;
            task.IsSolved = await this.TaskService.Update(taskId, new TaskModel(taskData)) ? newValue : !newValue;
            group.AllSolved = group.TaskList.Count(x => !x.IsSolved) == 0;
            group.OutOfRange = group.Deadline < DateTime.Now && !group.AllSolved;

            this.StateHasChanged();
        }

        private async void OpenAddTaskModal()
        {
            var parameters = new DialogParameters { { "TaskId", null } };
            var dialog = DialogService.Show<TaskDialog>("Create Task", parameters, new DialogOptions
            {
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetTasks();
            }
        }

        private async void OpenUpdateTaskModal(int taskId)
        {
            var parameters = new DialogParameters { { "TaskId", taskId } };
            var dialog = DialogService.Show<TaskDialog>("Update Task", parameters, new DialogOptions
            {
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            });
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetTasks();
            }
        }

        private async void OpenDeleteModal(TaskDto task)
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = task.Title,
                        Action = ConfirmType.Delete,
                        DeleteFunction = async () => await TaskService.Delete(task.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Task Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await this.GetTasks();
            }
        }


        private async void IsSolvedSelectorValueChanged(bool? value)
        {
            this.IsSolvedSelectorValue = value;
            await this.GetTasks();
        }
    }
}