using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AuthorId { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        //public virtual IList<string> Tags { get { return _Tags; } set { _Tags = value; } }
        public virtual ICollection<Comment> Comments { get; set; }

        //private IList<string> _Tags;
        //public string TagsSerialized
        //{
        //    get
        //    {
        //        return JsonConvert.SerializeObject(_Tags);
        //    }
        //    set
        //    {
        //        _Tags = JsonConvert.DeserializeObject<IList<string>>(value);
        //    }
        //}
    }
}
