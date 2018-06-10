using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi
{
    public class HttpPostedFile
    {
        public HttpPostedFile(string name, string filename, byte[] file)
        {
            Name = name;
            Filename = filename;
            File = file;
        }

        public string Name { get; private set; }
        public string Filename { get; private set; }
        public byte[] File { private set; get; }
    }
}
