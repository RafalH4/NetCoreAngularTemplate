using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.DataContext;
using WebApi.UserDirectory;

namespace WebApi.VeteranAwardDirectory
{
    public class VeteranAwardRepository: IVeteranAwardRepository
    {
        private readonly Context _context;
        public VeteranAwardRepository(Context context)
        {
            _context = context;
        }
        public async Task AddVeteranAward(VeteranAward veteranAward)
        {
            await _context.VeteranAwards.AddAsync(veteranAward);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Award> GetAwardById(Guid id)
        => await Task.FromResult(_context.Awards.FirstOrDefault(
                user => user.Id == id));

        public async Task<Veteran> GetVeteranById(Guid id)
        => await Task.FromResult(_context.Veterans.FirstOrDefault(
                user => user.Id == id));
    }
}
