using Microsoft.AspNetCore.Mvc;
using StudBaza.Application.Interfaces;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return new JsonResult(user);
        }

        //POST api/User/
        [HttpPost]
        [ValidateModel]
        [SwaggerRequestExample(typeof(CreateUser), typeof(CreateUserExample))]
        public async Task<IActionResult> Post([FromBody] CreateUser model)
        {
            var entity = model.MapEntity(model);

            var createdResult = await _userService.CreateUserAsync(entity);
            return new JsonResult(createdResult);
        }

        //PUT api/User/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Put(int id, [FromBody] CreateUser model)
        {
            var entity = model.MapEntity(model);
            entity.Id = id;

            var createdResult = await _userService.UpdateUserAsync(entity);
            return new JsonResult(createdResult);
        }

        //DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}
