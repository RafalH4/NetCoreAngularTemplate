using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.UserDirectory;

namespace WebApi.EnterpreneurSaleDirectory
{
    public interface IEnterpreneurSaleRepository
    {
        Task AddOffer(EnterpreneurSale addOffer);
        Task<User> GetUserById(Guid id);
        Task<Business> GetBusinessByUserId(Guid id);
        Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurOffers();
        Task<EnterpreneurSale> GetEnterpreneurOffersById(Guid id);
        Task<Enterpreneur> GetEnterpreneurByIdOffer(Guid id);
        Task<Business> GetBusinessByIdOffer(Guid id);
        Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurSalesWithStatistics();
        Task<EnterpreneurSale>GetEnterpreneurSaleWithStatistics(Guid id);
        Task<List<int>> GetRatingsByBusinessId(Guid id);
        Task<List<int>> GetRatingCount(Guid id);
    }
}
