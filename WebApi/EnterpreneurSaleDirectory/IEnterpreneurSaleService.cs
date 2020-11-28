using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.EnterpreneurSaleDirectory.Dto;
using WebApi.UserDirectory;

namespace WebApi.EnterpreneurSaleDirectory
{
    public interface IEnterpreneurSaleService
    {
        Task AddOffer(AddEnterpreneurOffer newOffer, Guid id);
        Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurOffers();
        Task<GetEnterpreneurOffer> GetEnterpreneurOffersById(Guid id);
        Task<IEnumerable<DiscountsWithStatisticsDto>>GetEnterpreneurSalesWithStatistics();
        Task<DiscountWithStatisticsDto> GetEnterpreneurSaleWithStatistics(Guid id);
    }
}
