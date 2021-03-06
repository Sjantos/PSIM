﻿using StudBaza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> UniqueUsername(string username);
        Task<User> GetUserById(int id);
        Task DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(User updatedUser);
        Task<User> CreateUserAsync(User model);
        Task<int?> CanLogin(string email, string passwordSHA);
    }
}
