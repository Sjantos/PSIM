using StudBaza.Core.Entities;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class CreatePost
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

        public Post MapEntity(CreatePost model, int authorId)
        {
            var contentType = GetContentType(model.FileName);
            if(contentType == null)
            {
                if (string.IsNullOrEmpty(model.FileType) || string.IsNullOrEmpty(model.FileName))
                    contentType = null;
                else
                    contentType = model.FileType;
            }
            var entity = new Post()
            {
                AuthorId = authorId,
                Comments = new List<Comment>(model.Comments),
                CreatedAt = DateTime.UtcNow,
                Description = model.Description,
                Tags = new List<Tag>(model.Tags),
                Title = model.Title,
                File = model.File,
                FileName = model.FileName,
                FileType = contentType
            };

            return entity;
        }

        private string GetContentType(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            string result;
            if (types.TryGetValue(ext, out result))
                return result;
            else
                return null;
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

    public class CreatePostExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreatePost()
            {
                Title = "Post title example",
                Description = "Post description example",
                CreatedAt = DateTime.UtcNow,
                AuthorUsername = "User45674", //fake userName
                //Tags = new List<string>()
                //{
                //    "newton",
                //    "physic",
                //    "gravitation"
                //},
                Tags = new List<Tag>()
                {
                    new Tag("newton"),
                    new Tag("physic"),
                    new Tag("gravitation")
                },
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        AuthorId = 11,
                        CommentContent = "Comment body example",
                        CreatedAt = DateTime.UtcNow,
                    }
                },
                File = "File bytes in Base64 as string",
                FileName = "obrazek.jpeg",
                FileType = "image/jpeg"
            };
        }
    }
}
