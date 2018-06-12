using StudBaza.Core.Entities;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class CreateComment
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public string AuthorUsername { get; set; }
        [Required]
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public Comment MapEntity(CreateComment model, int authorId)
        {
            var entity = new Comment()
            {
                PostId = model.PostId,
                AuthorId = authorId,
                CommentContent = model.CommentContent,
                CreatedAt = DateTime.UtcNow
            };
            return entity;
        }
    }

    public class CreateCommentExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreateComment()
            {
                PostId = 10, //fake
                AuthorUsername = "User875678", //fake
                CommentContent = "Comment content example",
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
