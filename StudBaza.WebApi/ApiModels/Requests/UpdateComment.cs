using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class UpdateComment
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string CommentContent { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public Comment MapEntity(UpdateComment model)
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
}
