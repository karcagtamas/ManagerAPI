﻿using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Components;

namespace EventManager.Client.Shared.Components.SL
{
    /// <summary>
    /// Movie comment
    /// </summary>
    public partial class MovieCommentComponent
    {
        /// <summary>
        /// Comment
        /// </summary>
        [Parameter] public MovieCommentListDto Comment { get; set; }

        /// <summary>
        /// Refresh
        /// </summary>
        [Parameter] public EventCallback Refresh { get; set; }

        /// <summary>
        /// Movie Id
        /// </summary>
        [Parameter] public int MovieId { get; set; }

        [Inject] private IMovieCommentService MovieCommentService { get; set; }

        private bool IsEdit { get; set; }
        private string CommentText { get; set; }

        private async void DeleteComment()
        {
            if (await this.MovieCommentService.Delete(this.Comment.Id))
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
                await this.MovieCommentService.Update(this.Comment.Id,
                    new MovieCommentModel { Comment = this.CommentText, MovieId = this.MovieId }))
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