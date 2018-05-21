using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> CreatePostAsync(Post model)
        {
            var r = await _postRepository.AddAsync(model);
            await _postRepository.SaveAsync();

            return r;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.FindOneByAsync(p => p.Id == id);
            if (post == null)
                return;
            _postRepository.Delete(post);
            await _postRepository.SaveAsync();
        }

        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return _postRepository.GetAllAsync();
        }

        public Task<Post> GetPostById(int id)
        {
            return _postRepository.FindOneByAsync(p => p.Id == id);
        }

        public async Task<Post> UpdatePostAsync(Post updatedPanel)
        {
            var existingPost = await GetPostById(updatedPanel.Id);
            if (existingPost == null)
                return null;
            var r = await _postRepository.UpdateAsync(updatedPanel, existingPost.Id);
            await _postRepository.SaveAsync();
            return r;
        }
    }
}
