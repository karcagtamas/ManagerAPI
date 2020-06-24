using EventManager.Client.Models;
using EventManager.Client.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetNewsPosts();
        Task<bool> PostNews(PostModel model);
        Task<bool> UpdateNews(int postId, PostModel model);
        Task<bool> DeleteNews(int postId);
    }
}