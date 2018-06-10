using Microsoft.AspNetCore.Mvc;
using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        //POST api/Login
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Credentials body)
        {
            var logged = await _userService.CanLogin(body.Login, body.Password);
            if (!logged)
                return new JsonResult("Bad credentials");

            return Ok();
        }
    }
}
