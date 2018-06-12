using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Core.Entities
{
    public class ResponseComment
    {
        public int Id { get; set; }
        public string AuthorUsername { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
    }
}
