using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Post Post { get; set; }
    }
}
