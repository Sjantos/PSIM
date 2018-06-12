using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.Core.Entities
{
    public class ResponsePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public string AuthorUsername { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        //public virtual IList<string> Tags { get { return _Tags; } set { _Tags = value; } }
        public virtual ICollection<ResponseComment> Comments { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
