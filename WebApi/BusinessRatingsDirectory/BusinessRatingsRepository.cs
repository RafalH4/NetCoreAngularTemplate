using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.BusinessRatingsDirectory.Dto;
using WebApi.DataContext;
using WebApi.UserDirectory;

namespace WebApi.BusinessRatingsDirectory
{
    public class BusinessRatingsRepository : IBusinessRatingsRepository
    {
        private readonly Context _context;
        public BusinessRatingsRepository(Context context)
        {
            _context = context;
        }

        public async Task AddRate(BusinessRatings newRate)
        {
            await _context.BusinessesRatings.AddAsync(newRate);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Business> GetBusinessById(Guid businessID)
        => await Task.FromResult(_context.Businesses.FirstOrDefault(
                business => business.Id == businessID));

        public async Task<IEnumerable<BusinessRatings>> GetBusinessRatings(Guid BusinessID)
        {
            return  _context.BusinessesRatings.Where(br => br.Business.Id == BusinessID).Include(b=>b.Veteran).ToList();
        }

        public async Task<Veteran> GetVeteranById(Guid veteranID)
        => await Task.FromResult(_context.Veterans.FirstOrDefault(
                veteran => veteran.Id == veteranID));
    }
}
