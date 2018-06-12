using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<int> GetAuthorId(string username)
        {
            return (await _userRepository.FindOneByAsync(p => p.Username.Equals(username))).Id;
        }

        public async Task<Comment> CreateCommentAsync(Comment model)
        {
            var r = await _commentRepository.AddAsync(model);
            await _commentRepository.SaveAsync();

            return r;
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.FindOneByAsync(p => p.Id == id);
            if (comment == null)
                return;
            _commentRepository.Delete(comment);
            await _commentRepository.SaveAsync();
        }

        public async Task<IEnumerable<ResponseComment>> GetAllComments()
        {
            var comments = await _commentRepository.GetAllAsync();

            var result = comments.Select(async p => p.GetResponseComment((await _userRepository.FindOneByAsync(u => u.Id == p.AuthorId)).Username));
            return Task.WhenAll(result).Result;
        }

        public async Task<ResponseComment> GetCommentById(int id)
        {
            var comment = await _commentRepository.FindOneByAsync(p => p.Id == id);
            var result = comment.GetResponseComment((await _userRepository.FindOneByAsync(p => p.Id == comment.AuthorId)).Username);
            return result;
        }

        public async Task<IEnumerable<ResponseComment>> GetCommentsForPost(int postId)
        {
            var comments = await _commentRepository.FindByAsync(p => p.PostId == postId);
            var result = comments.Select(async p => p.GetResponseComment((await _userRepository.FindOneByAsync(u => u.Id == p.AuthorId)).Username));
            return Task.WhenAll(result).Result;
        }

        public async Task<Comment> UpdateCommentAsync(Comment updatedComment)
        {
            var existingComment = await GetCommentById(updatedComment.Id);
            if (existingComment == null)
                return null;
            var r = await _commentRepository.UpdateAsync(updatedComment, existingComment.Id);
            await _commentRepository.SaveAsync();
            return r;
        }
    }
}
