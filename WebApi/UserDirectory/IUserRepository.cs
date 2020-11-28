using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UserDirectory
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Veteran>> GetVeterans();
        Task<IEnumerable<Veteran>> GetInactiveVeterans();
        Task<Veteran> GetVeteranById(Guid id);
        Task<IEnumerable<Enterpreneur>> GetEnterpreneurs(Guid id);
        Task AddFriend(Veteran friend);
        Task<Veteran> GetFriends(Guid id);
        Task<Veteran> GetVeteranWithFriendById(Guid id);
        Task UpdateVeteran(Veteran veteran);
    }
}
