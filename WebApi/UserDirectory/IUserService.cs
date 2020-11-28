using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    public interface IUserService
    {
        Task AddClient(AddUserDto userDto);
        Task AddEnterpreneur(AddUserDto userDto);
        Task AddAdmin(AddUserDto userDto);
        Task ActivateAccount(string email, string id);
        Task ResetPassword(string email);
        Task RemoveUser(Guid id);
        Task UpdateUser(UpdateUserDto userDto);
        Task ChangePassword(ChangePasswordDto password);
        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task<string> Login(UserLoginDto userLogin);
        Task<IEnumerable<GetVeteran>> GetVeterans();
        Task<IEnumerable<GetVeteran>> GetInactiveVeterans();
        Task<GetVeteran> GetVeteran(Guid id);
        Task<IEnumerable<GetEnterpreneur>> GetEnterpreneurs(Guid id);
        Task AddFriend(Guid idFriend, Guid idVeteran);
        Task<IEnumerable<GetFriendDto>> GetFriends(Guid id);
        Task ActivateCard(Guid id);
    }
}
