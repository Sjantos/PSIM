using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class UpdatePost
    {
        [Required]
        public string AuthorUsername { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public string File { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public Post MapEntity(UpdatePost model, int authorId)
        {
            var entity = new Post()
            {
                AuthorId = authorId,
                Comments = new List<Comment>(model.Comments),
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                Tags = new List<Tag>(model.Tags),
                Title = model.Title,
                File = model.File,
                FileName = model.FileName,
                FileType = GetContentType(model.FileName)
            };

            return entity;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
