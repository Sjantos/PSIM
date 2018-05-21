using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using StudBaza.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Data.Repositories
{
    public class CommentRepository : EfRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
