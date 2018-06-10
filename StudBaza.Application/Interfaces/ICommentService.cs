using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> GetAuthorId(string username);
        Task<IEnumerable<Comment>> GetAllComments();
        Task<IEnumerable<Comment>> GetCommentsForPost(int postId);
        Task<Comment> GetCommentById(int id);
        Task DeleteCommentAsync(int id);
        Task<Comment> UpdateCommentAsync(Comment updatedComment);
        Task<Comment> CreateCommentAsync(Comment model);
    }
}
