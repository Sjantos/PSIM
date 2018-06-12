using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using StudBaza.Core.Entities;

namespace StudBaza.Data.Context
{
    public static class AppDbContextSeed
    {
        public static void Seed(AppDbContext ctx)
        {
            //ctx.AddRange(SeedProjects);
            ctx.AddRange(SeedPosts);
            ctx.AddRange(SeedUsers);

            ctx.SaveChanges();
        }

        private static List<User> _seedUsers;
        private static List<User> SeedUsers => _seedUsers ?? (_seedUsers = new List<User>()
        {
            new User()
            {
                Email = "defaultUser@mail.com",
                Username = "DefaultUsername",
                Password = "wnrfjwqnfjwnqrfgnwjklergnklwegjklnjkwlegn"
            }
        });

        private static List<Post> _seedPosts;
        private static List<Post> SeedPosts => _seedPosts ?? (_seedPosts = new List<Post>()
        {
            new Post()
            {
                Title = "Post title example",
                Description = "Post description example",
                CreatedAt = DateTime.UtcNow,
                AuthorId = 1, //fake userID
                Tags = new List<Tag>()
                {
                    new Tag("newton"),
                    new Tag("physic"),
                    new Tag("gravitation")
                },
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        AuthorId = 1,
                        CommentContent = "Comment body example",
                        CreatedAt = DateTime.UtcNow,
                    }
                }
            }
        });
    }
}
