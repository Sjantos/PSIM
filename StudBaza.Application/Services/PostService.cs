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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentService _commentService;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ICommentService commentService)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentService = commentService;
        }

        public async Task<(string, string, string)> GetFile(int postId)
        {
            var postWithFile = (await _postRepository.FindOneByAsync(p => p.Id == postId));
            if (postWithFile == null)
                return (null, null, null);
            return (postWithFile.FileName, postWithFile.FileType, postWithFile.File);
        }

        public async Task<int> GetAuthorId(string authorUsername)
        {
            return (await _userRepository.FindOneByAsync(p => p.Username.Equals(authorUsername))).Id;
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

        public async Task<IEnumerable<ResponsePost>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            //List<ResponsePost> res = new List<ResponsePost>();
            //foreach (var item in posts)
            //{
            //    var authorUsername = (await _userRepository.FindOneByAsync(u => u.Id == item.AuthorId)).Username;
            //    var responsePost = item.ConvertToResponseModel(authorUsername);
            //    res.Add(responsePost);
            //}

            var result = posts.Select(async p => 
                p.ConvertToResponseModel(   (await _userRepository.FindOneByAsync(u => u.Id == p.AuthorId)).Username,
                                            (await _commentService.GetCommentsForPost(p.Id)).ToList())
                                        );
            return Task.WhenAll(result).Result;
        }

        public async Task<ResponsePost> GetPostById(int id)
        {
            var post = await _postRepository.FindOneByAsync(p => p.Id == id);
            return post.ConvertToResponseModel( (await _userRepository.FindOneByAsync(p => p.Id == post.AuthorId)).Username,
                                                   (await _commentService.GetCommentsForPost(post.Id)).ToList());
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
