using Microsoft.AspNetCore.Mvc;
using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
using StudBaza.WebApi.ApiModels;
using StudBaza.WebApi.ApiModels.Requests;
using StudBaza.WebApi.Infrastructure;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        //GET api/Post
        [HttpGet]
        public async Task<IEnumerable<ResponsePost>> Get()
        {
            var allPosts = await _postService.GetAllPostsAsync();
            return allPosts;
        }

        //GET api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
                return NotFound();
            return new JsonResult(post);
        }

        //POST api/Post/
        [HttpPost]
        [ValidateModel]
        [SwaggerRequestExample(typeof(CreatePost), typeof(CreatePostExample))]
        public async Task<IActionResult> Post([FromBody] CreatePost model)
        {
            var entity = model.MapEntity(model, await _postService.GetAuthorId(model.AuthorUsername));

            var createdResult = await _postService.CreatePostAsync(entity);
            return new JsonResult(createdResult);
        }

        //PUT api/Post/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePost model)
        {
            var entity = model.MapEntity(model, await _postService.GetAuthorId(model.AuthorUsername));
            entity.Id = id;

            var createdResult = await _postService.UpdatePostAsync(entity);
            return new JsonResult(createdResult);
        }

        //DELETE api/Post/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postService.DeletePostAsync(id);
        }
    }
}
