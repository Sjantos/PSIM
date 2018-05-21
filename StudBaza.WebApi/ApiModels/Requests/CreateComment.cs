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
        public int AuthorId { get; set; }
        [Required]
        public string CommentContent { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Comment MapEntity(CreateComment model)
        {
            var entity = new Comment()
            {
                AuthorId = model.AuthorId,
                CommentContent = model.CommentContent,
                CreatedAt = model.CreatedAt
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
                AuthorId = 11, //fake
                CommentContent = "Comment content example",
                CreatedAt = DateTime.Now
            };
        }
    }
}
