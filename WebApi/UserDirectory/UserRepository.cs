using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.UserDirectory
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddFriend(Veteran veteran)
        {
            _context.Veterans.Update(veteran);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Enterpreneur>> GetEnterpreneurs(Guid id)
        => await Task.FromResult(_context.Enterpreneurs.Where(ent => ent.Business.Id == id).ToList());

        public async Task<Veteran> GetFriends(Guid id)
        {
            var x = _context.Veterans.Where(vet => vet.Id == id).Include(s => s.Friends).SingleOrDefault();
            return x;
        }

        public async Task<IEnumerable<Veteran>> GetInactiveVeterans()
         => await Task.FromResult(_context.Veterans.Where(v => v.IsActive == false).ToList());

        public async Task<User> GetUserByEmail(string email)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Email == email));

        public async Task<User> GetUserById(Guid id)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Id == id));

        public async Task<IEnumerable<User>> GetUsers()
            => await Task.FromResult(_context.Users.ToList());

        public async Task<Veteran> GetVeteranWithFriendById(Guid id)
        {
            var x = await _context
                .Veterans
                .Where(v => v.Id == id)
                .Include(v => v.Friends)
                .SingleOrDefaultAsync();
            return x;
        }
        public async Task<Veteran> GetVeteranById(Guid id)
        {
            var x = await _context
                .Veterans
                .Where(v => v.Id == id)
                .SingleOrDefaultAsync();
            return x;
        }

        public async Task<IEnumerable<Veteran>> GetVeterans()
        => await Task.FromResult(_context.Veterans.ToList());

        public async Task RemoveUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task UpdateVeteran(Veteran veteran)
        {
            _context.Users.Update(veteran);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
