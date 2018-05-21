using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
