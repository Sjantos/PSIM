using Microsoft.AspNetCore.Mvc;
using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //GET api/Comment
        [HttpGet]
        public async Task<IEnumerable<Comment>> Get()
        {
            var allPosts = await _commentService.GetAllComments();
            return allPosts;
        }

        //GET api/Comment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _commentService.GetCommentById(id);
            if (post == null)
                return NotFound();
            return new JsonResult(post);
        }

        //GET api/Comment/ForPost/5
        [HttpGet("ForPost/{postId}")]
        public async Task<IActionResult> ForPost(int postId)
        {
            var posts = await _commentService.GetCommentsForPost(postId);
            return new JsonResult(posts);
        }

        //POST api/Comment/
        [HttpPost]
        [ValidateModel]
        [SwaggerRequestExample(typeof(CreateComment), typeof(CreateCommentExample))]
        public async Task<IActionResult> Post([FromBody] CreateComment model)
        {
            var entity = model.MapEntity(model, await _commentService.GetAuthorId(model.AuthorUsername));

            var createdResult = await _commentService.CreateCommentAsync(entity);
            return new JsonResult(createdResult);
        }

        //PUT api/Comment/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateComment model)
        {
            var entity = model.MapEntity(model, await _commentService.GetAuthorId(model.AuthorUsername));
            entity.Id = id;

            var createdResult = await _commentService.UpdateCommentAsync(entity);
            return new JsonResult(createdResult);
        }

        //DELETE api/Comment/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _commentService.DeleteCommentAsync(id);
        }
    }
}
