using Microsoft.AspNetCore.Mvc;
using StudBaza.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IPostService _postService;

        public FileController(IPostService postService)
        {
            _postService = postService;
        }

        //GET api/File/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var file = await _postService.GetFile(id);
            if (file.Item1 == null)
                return NotFound();

            return new JsonResult(new MyFile() { FileName = file.Item1, FileType = file.Item2, File = file.Item3 });
        }
    }

    class MyFile
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string File { get; set; }
    }
}
