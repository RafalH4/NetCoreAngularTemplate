using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.UserDirectory;
using WebApi.VeteranSaleDirectory.Dto;

namespace WebApi.VeteranSaleDirectory
{
    public class VeteranSaleRepository: IVeteranSaleRepository
    {
        private readonly Context _context;
        public VeteranSaleRepository(Context context)
        {
            _context = context;
        }
        public async Task AddOffer(VeteranSale addOffer)
        {
            await _context.VeteranSales.AddAsync(addOffer);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<User> GetUserById(Guid id)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Id == id));

        public async Task<Veteran> GetVeteranBySaleId(Guid id)
        {
            var x = _context.VeteranSales.Where(c => c.Id == id).Select(x=>x.Veteran).FirstOrDefault();
            return  x;
        }

        public async Task<List<VeteranSale>> GetVeteranOffers()
            => await Task.FromResult(_context.VeteranSales.ToList());


    }
}
