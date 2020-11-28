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

            var newUser = new VeteranCenter
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CreatedAt = DateTime.Now,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password)),
                IsActive = true
            };
            //_emailSender.SendConfirmationEmain("Jan", "Kowalski", newUser.Email, newUser.Id);
            await _userRepository.AddUser(newUser);
        }
        
        public async Task AddEnterpreneur(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new Enterpreneur
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CreatedAt = DateTime.Now,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password)),
                IsActive = true
            };
            // _emailSender.SendConfirmationEmain("Jan", "Kowalski", newUser.Email, newUser.Id);
            await _userRepository.AddUser(newUser);
        }
        public async Task AddClient(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new Veteran
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordSalt = hmac.Key,
                CreatedAt = DateTime.Now,
                isVeteranCardActive = false,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password)),
                IsActive = true,
                Pesel = userDto.Pesel,
                VeteranCardNumber = userDto.VeteranCardNumber
            };
           // _emailSender.SendConfirmationEmain("Jan", "Kowalski", newUser.Email, newUser.Id);
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
            /*if (!userFromDb.IsActive)
                throw new Exception("Not activated account");
            */
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

        public Task ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetVeteran>> GetVeterans()
        {

            var veteran = await _userRepository.GetVeterans();
            return veteran.Select(veteran => new GetVeteran()
            {
                Id = veteran.Id,
                isVeteranCardActive = veteran.isVeteranCardActive,
                Email = veteran.Email,
                FirstName = veteran.FirstName,
                LastName = veteran.LastName,
                Pesel = veteran.Pesel,
                AwatarUrl = veteran.AwatarUrl,
                CreatedAt = veteran.CreatedAt,
                DamageToHealth = veteran.DamageToHealth,
                VeteranCardNumber = veteran.VeteranCardNumber,
                IsActive = veteran.IsActive
            });
        }

        public async Task<IEnumerable<GetVeteran>> GetInactiveVeterans()
        {
            var veteran = await _userRepository.GetInactiveVeterans();
            return veteran.Select(veteran => new GetVeteran()
            {
                Id = veteran.Id,
                Email = veteran.Email,
                FirstName = veteran.FirstName,
                LastName = veteran.LastName,
                Pesel = veteran.Pesel,
                AwatarUrl = veteran.AwatarUrl,
                CreatedAt = veteran.CreatedAt,
                DamageToHealth = veteran.DamageToHealth,
                VeteranCardNumber = veteran.VeteranCardNumber,
                IsActive = veteran.IsActive
            });
        }

        public async Task<GetVeteran> GetVeteran(Guid id)
        {
            var veteran = await _userRepository.GetVeteranById(id);
            return new GetVeteran()
            {
                Id = veteran.Id,
                FirstName = veteran.FirstName,
                LastName = veteran.LastName,
                Pesel = veteran.Pesel,
                VeteranCardNumber = veteran.VeteranCardNumber,
                AwatarUrl = veteran.AwatarUrl,
                CreatedAt = veteran.CreatedAt,
                IsActive = veteran.IsActive,
                DamageToHealth = veteran.DamageToHealth,
                Email = veteran.Email
            };
        }

        public async Task<IEnumerable<GetEnterpreneur>> GetEnterpreneurs(Guid id)
        {
            var enterpreneurs = await _userRepository.GetEnterpreneurs(id);
            return enterpreneurs.Select(enterpreneurs => new GetEnterpreneur()
            {
                FirstName = enterpreneurs.FirstName,
                LastName = enterpreneurs.LastName,
                Id = enterpreneurs.Id,
                AwatarUrl = enterpreneurs.AwatarUrl,
                CreatedAt = enterpreneurs.CreatedAt,
                Email = enterpreneurs.Email,
                IsActive = enterpreneurs.IsActive
            });
        }

        public async Task AddFriend(Guid idF, Guid idV)
        {
            var friend = await _userRepository.GetVeteranById(idF);
            var veteran = await _userRepository.GetVeteranWithFriendById(idV);
            if (veteran.Friends.Select(x => x.Id).Contains(friend.Id))
                throw new Exception("Is your friend already");
            veteran.Friends.Add(friend);
            await _userRepository.AddFriend(veteran);
        }

        public async Task<IEnumerable<GetFriendDto>> GetFriends(Guid id)
        {
            var veteran = await _userRepository.GetFriends(id);
            return veteran.Friends.Select(friends => new GetFriendDto ()
            {
                Id = friends.Id,
                FirstName = friends.FirstName,
                LastName = friends.LastName,
                AwatarUrl = friends.AwatarUrl,
                DamageToHealth = friends.DamageToHealth,
                Email = friends.Email
            });
        }

        public async Task ActivateCard(Guid id)
        {
            var veteran =  _userRepository.GetVeteranById(id).Result;
            veteran.isVeteranCardActive = true;
            await _userRepository.UpdateVeteran(veteran);
        }
    }
}
