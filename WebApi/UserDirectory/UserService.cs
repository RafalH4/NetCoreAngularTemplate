using System;
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
        private readonly IEmailSender _emailSender;
        public UserService(IUserRepository userRepository,
             IJwtHandler jwtHandler,
             IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _emailSender = emailSender;
        }
        public async Task AddAdmin(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new UserAdmin
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password)),
                IsActive = false
            };
            _emailSender.SendConfirmationEmain("Jan", "Kowalski", newUser.Email, newUser.Id);
            await _userRepository.AddUser(newUser);
        }

        public async Task AddClient(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new UserClient
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password)),
                IsActive = false    
            };
            _emailSender.SendConfirmationEmain("Jan", "Kowalski", newUser.Email, newUser.Id);
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
                throw new Exception("Bad email");
            if (!userFromDb.CheckPassword(userLogin.Password))
                throw new Exception("Bad password");
            if (!userFromDb.IsActive)
                throw new Exception("Not activated account");

            return _jwtHandler.CreateToken(userFromDb);
        }

        public async Task ActivateAccount(string email, string id)
        {
            var userFromDb = await _userRepository.GetUserByEmail(email);
            if (userFromDb == null || userFromDb.Id.ToString() != id)
                throw new Exception("Bad activation");
            userFromDb.IsActive = true;
            await _userRepository.UpdateUser(userFromDb);

        }
    }
}
