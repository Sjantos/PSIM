using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;

namespace StudBaza.Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostById(int id);
        Task DeletePostAsync(int id);
        Task<Post> UpdatePostAsync(Post updatedPanel);
        Task<Post> CreatePostAsync(Post model);
    }
}
