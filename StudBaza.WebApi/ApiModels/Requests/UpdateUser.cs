using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudBaza.WebApi.ApiModels.Requests
{
    public class UpdateUser
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
}
