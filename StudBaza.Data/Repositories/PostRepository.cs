using Microsoft.EntityFrameworkCore;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using StudBaza.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Data.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await Context.Set<Post>()
                .ToListAsync();
        }

        public override Task<Post> GetByIdAsync(int id)
        {
            return Context.Set<Post>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
