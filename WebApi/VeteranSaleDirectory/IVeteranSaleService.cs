using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;
using WebApi.VeteranSaleDirectory.Dto;

namespace WebApi.VeteranSaleDirectory
{
    public interface IVeteranSaleService
    {
        Task AddOffer(AddVeteranOffer newOffer, Guid id);
        Task<List<GetVeteranOffers>> GetVeteranOffers();
    }
}
