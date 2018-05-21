using StudBaza.Application.Interfaces;
using StudBaza.Core.Entities;
using StudBaza.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudBaza.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User model)
        {
            if (null != _userRepository.FindOneByAsync(p => p.Email.Equals(model.Email)))
                return null;
            var r = await _userRepository.AddAsync(model);
            await _userRepository.SaveAsync();
            return r;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.FindOneByAsync(p => p.Id == id);
            if (user == null)
                return;
            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }

        public Task<User> GetUserById(int id)
        {
            return _userRepository.FindOneByAsync(p => p.Id == id);
        }

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            var existingUser = await GetUserById(updatedUser.Id);
            if (existingUser == null)
                return null;
            var r = await _userRepository.UpdateAsync(updatedUser, existingUser.Id);
            await _userRepository.SaveAsync();
            return r;
        }

        public async Task<bool> CanLogin(string email, string passwordSHA)
        {
            var user = await _userRepository.FindOneByAsync(p => p.Email.Equals(email));
            if (user == null)
                return false;
            if (user.Password.Equals(passwordSHA))
                return true;
            return false;
        }
    }
}
