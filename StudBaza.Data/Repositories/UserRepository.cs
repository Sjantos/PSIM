using Microsoft.EntityFrameworkCore;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using StudBaza.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Data.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<User> FindOneByAsync(Expression<Func<User, bool>> match)
        {
            var result = await Context.Set<User>().SingleOrDefaultAsync(match);
            if (result != null)
                return result;
            else
                return null;
        }
    }
}
