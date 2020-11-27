using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EnterpreneurSaleDirectory.Dto;
using WebApi.UserDirectory;

namespace WebApi.EnterpreneurSaleDirectory
{
    public class EnterpreneurSaleService : IEnterpreneurSaleService
    {
        private readonly IEnterpreneurSaleRepository _enterpreneurSaleRepository;

        public EnterpreneurSaleService(IEnterpreneurSaleRepository enterpreneurSaleRepository)
        {
            _enterpreneurSaleRepository = enterpreneurSaleRepository;
        }
        public async Task AddOffer(AddEnterpreneurOffer newOffer, Guid id)
        {
            var business = await _enterpreneurSaleRepository.GetBusinessByUserId(id);
            var user = await _enterpreneurSaleRepository.GetUserById(id);
            var addOffer = new EnterpreneurSale();
            addOffer.Id = Guid.NewGuid();
            addOffer.SaleName = newOffer.SaleName;
            addOffer.SaleDescription = newOffer.SaleDescription;
            addOffer.isActivated = true;
            addOffer.DateFrom = newOffer.DateFrom;
            addOffer.DateTo = newOffer.DateTo;
            addOffer.Discount = newOffer.Discount;
            addOffer.Enterpreneur = (UserDirectory.Enterpreneur)user;
            addOffer.Business = business;
            await _enterpreneurSaleRepository.AddOffer(addOffer);

        }

        public async Task<IEnumerable<EnterpreneurSale>> GetEnterpreneurOffers()
           => await _enterpreneurSaleRepository.GetEnterpreneurOffers();

        public async Task<GetEnterpreneurOffer> GetEnterpreneurOffersById(Guid id)
        {
            var sales = await _enterpreneurSaleRepository.GetEnterpreneurOffersById(id);
            var enterpreneur = await _enterpreneurSaleRepository.GetEnterpreneurByIdOffer(id);
            var business = await _enterpreneurSaleRepository.GetBusinessByIdOffer(id);
            return new GetEnterpreneurOffer() {
                Business = new BusinessDto(){ 
                    Address = business.Address,
                    BusinessName = business.BusinessName,
                    Lattitude = business.Lattitude,
                    Longitude = business.Longitude,
                    PhotoUrl = business.PhotoUrl
                },
                Sale = new SaleDto() { 
                    isActivated = sales.isActivated,
                    SaleDescription = sales.SaleDescription,
                    SaleName = sales.SaleName,
                    DateFrom = sales.DateFrom,
                    DateTo = sales.DateTo,
                    Discount = sales.Discount
                },
                Enterpreneur = new EnterpreneurDto() { 
                    AwatarUrl = enterpreneur.AwatarUrl,
                    Email = enterpreneur.Email,
                    FirstName = enterpreneur.FirstName,
                    LastName = enterpreneur.LastName
                }
            };
        }


    }
}
