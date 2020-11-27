using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory.Dto;
using WebApi.DataContext;

namespace WebApi.AwardDirectory
{
    public class AwardRepository : IAwardRepository
    {
        private readonly Context  _context;
        public AwardRepository(Context context)
        {
            _context = context;
        }
        public async Task AddAward(Award award)
        {
            await _context.Awards.AddAsync(award);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Award>> GetAwards()
        => await Task.FromResult(_context.Awards.ToList());
    }
}
