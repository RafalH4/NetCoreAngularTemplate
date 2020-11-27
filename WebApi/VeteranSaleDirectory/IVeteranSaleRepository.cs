using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;
using WebApi.VeteranSaleDirectory.Dto;

namespace WebApi.VeteranSaleDirectory
{
    public interface IVeteranSaleRepository
    {
        Task AddOffer(VeteranSale addOffer);
        Task<User> GetUserById(Guid id);
        Task<List<VeteranSale>> GetVeteranOffers();
        Task<Veteran> GetVeteranBySaleId(Guid id);
    }
}
