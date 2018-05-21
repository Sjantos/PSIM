using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class UpdatePost
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

        public Post MapEntity(UpdatePost model)
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
}
