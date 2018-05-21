using StudBaza.Core.Entities;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class CreatePost
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public Post MapEntity(CreatePost model)
        {
            var entity = new Post()
            {
                AuthorId = model.AuthorId,
                Comments = new List<Comment>(model.Comments),
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                Tags = new List<Tag>(model.Tags),
                Title = model.Title
            };

            return entity;
        }
    }

    public class CreatePostExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreatePost()
            {
                Title = "Post title example",
                Description = "Post description example",
                CreatedAt = DateTime.Now,
                AuthorId = 11, //fake userID
                //Tags = new List<string>()
                //{
                //    "newton",
                //    "physic",
                //    "gravitation"
                //},
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
                        AuthorId = 11,
                        CommentContent = "Comment body example",
                        CreatedAt = DateTime.Now,
                    }
                }
            };
        }
    }
}
