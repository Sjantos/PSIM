using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudBaza.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId"), Required]
        public virtual Post Post { get; set; }

        public ResponseComment GetResponseComment(string authorUsername)
        {
            return new ResponseComment()
            {
                Id = this.Id,
                AuthorUsername = authorUsername,
                CommentContent = this.CommentContent,
                CreatedAt = this.CreatedAt,
                PostId = this.PostId
            };
        }
    }
}
