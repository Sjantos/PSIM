using StudBaza.Core.Entities;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class CreateUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public User MapEntity(CreateUser model)
        {
            var entity = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };
            return entity;
        }
    }

    public class CreateUserExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreateUser()
            {
                Email = "example@mail.com",
                Password = "SHA_GOES_HERE_kwhqbrfiq7wy4hr983hr",
                Username = "ExampleUsername"
            };
        }
    }
}
