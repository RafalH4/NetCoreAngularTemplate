using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.DataContext;
using WebApi.EnterpreneurSaleDirectory.Dto;
using WebApi.UserDirectory;

namespace WebApi.EnterpreneurSaleDirectory
{
    public class EnterpreneurSaleRepository: IEnterpreneurSaleRepository
    {
        private readonly Context _context;
        public EnterpreneurSaleRepository(Context context)
        {
            _context = context;
        }
        public async Task AddOffer(EnterpreneurSale addOffer)
        {
            await _context.EnterpreneurSales.AddAsync(addOffer);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<User> GetUserById(Guid id)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Id == id));

        public async Task<Business> GetBusinessByUserId(Guid id)
            => await Task.FromResult(_context.Enterpreneurs.FirstOrDefault(
                enterp => enterp.Id == id).Business);

        public async Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurOffers()
            => await Task.FromResult(_context.EnterpreneurSales.ToList());

        public async Task<EnterpreneurSale> GetEnterpreneurOffersById(Guid id)
        => await Task.FromResult(_context.EnterpreneurSales.FirstOrDefault(
                enterp => enterp.Id == id));

        public async Task<Enterpreneur> GetEnterpreneurByIdOffer(Guid id)
        {
            var x = _context.EnterpreneurSales.Where(c => c.Id == id).Select(x => x.Enterpreneur).FirstOrDefault();
            return x;
        }

        public async Task<Business> GetBusinessByIdOffer(Guid id)
        {
            var x = _context.EnterpreneurSales.Where(c => c.Id == id).Select(x => x.Business).FirstOrDefault();
            return x;
        }

        public async Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurSalesWithStatistics()
            => await  Task.FromResult(_context.EnterpreneurSales
                .Include(s => s.Business)
                .ToList());

        public async Task<List<int>> GetRatingsByBusinessId(Guid BusinessID)
            => await Task.FromResult(_context.BusinessesRatings.Where(s => s.Business.Id == BusinessID).Select(s => s.Rate).ToList());

        public async Task<EnterpreneurSale> GetEnterpreneurSaleWithStatistics(Guid id)
            => await Task.FromResult(_context.EnterpreneurSales.Where(x => x.Id == id).Include(x => x.Business).SingleOrDefault());

        public async Task<List<int>> GetRatingCount(Guid id)
            => await Task.FromResult(_context.BusinessesRatings.Where(s => s.Business.Id == id).Select(s => s.Rate).ToList());
    }

}
