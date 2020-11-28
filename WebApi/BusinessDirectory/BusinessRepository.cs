using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.BusinessDirectory
{
    public class BusinessRepository: IBusinessRepository
    {
        private readonly Context _context;
        public BusinessRepository(Context context)
        {
            _context = context;
        }

        public async Task AddBusiness(Business business)
        {
            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Business> GetBusiness(Guid id)
        => await Task.FromResult(_context.Businesses.Where(b => b.Id == id).FirstOrDefault());

        public async Task<IEnumerable<Business>> GetBusinesses()
        => await Task.FromResult(_context.Businesses.ToList());

        public async Task<Business> GetBusinessInfo(Guid id)
        => await Task.FromResult(_context.Businesses.Where(b => b.Id == id).FirstOrDefault());
    }
}
