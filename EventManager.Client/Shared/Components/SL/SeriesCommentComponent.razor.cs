using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Series Comment Component
    /// </summary>
    public partial class SeriesCommentComponent
    {
        /// <summary>
        /// Comment
        /// </summary>
        [Parameter] public SeriesCommentListDto Comment { get; set; }

        /// <summary>
        /// Refresh
        /// </summary>
        [Parameter] public EventCallback Refresh { get; set; }

        /// <summary>
        /// Series Id
        /// </summary>
        [Parameter] public int SeriesId { get; set; }
        [Inject] private ISeriesCommentService SeriesCommentService { get; set; }
        private bool IsEdit { get; set; }
        private string CommentText { get; set; }

        private async void DeleteComment()
        {
            if (await this.SeriesCommentService.Delete(this.Comment.Id))
            {
                await this.Refresh.InvokeAsync(null);
            }
        }

        private void EditComment()
        {
            this.IsEdit = true;
            this.CommentText = this.Comment.Comment;
            this.StateHasChanged();
        }

        private async void SaveEdit()
        {
            if (!string.IsNullOrEmpty(this.CommentText) &&
                await this.SeriesCommentService.Update(this.Comment.Id,
                    new SeriesCommentModel { Comment = this.CommentText, SeriesId = this.SeriesId }))
            {
                await this.Refresh.InvokeAsync(null);
            }
        }

        private void CancelEdit()
        {
            this.IsEdit = false;
        }
    }
}