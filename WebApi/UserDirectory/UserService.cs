﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        public UserService(IUserRepository userRepository,
             IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }
        public async Task AddAdmin(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Bad user");

            var hmac = new HMACSHA512();

            var newUser = new UserAdmin
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password))
            };

            await _userRepository.AddUser(newUser);
        }

        public async Task AddClient(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Bad user");

            var hmac = new HMACSHA512();

            var newUser = new UserClient
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password))
            };

            await _userRepository.AddUser(newUser);
        }

        public Task ChangePassword(ChangePasswordDto password)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<User>> GetUsers()
            => await _userRepository.GetUsers();

        public async Task<User> GetUser(Guid id)
            => await _userRepository.GetUserById(id);

        public async Task RemoveUser(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user != null)
                await _userRepository.RemoveUser(user);
        }

        public async Task UpdateUser(UpdateUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(UserLoginDto userLogin)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userLogin.Email);
            if (userFromDb == null)
                throw new Exception("No user");
            if (!userFromDb.CheckPassword(userLogin.Password))
                throw new Exception("Bad password");

            return _jwtHandler.CreateToken(userFromDb);
        }
    }
}
