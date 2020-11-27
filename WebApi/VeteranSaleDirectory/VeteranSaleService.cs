using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;
using WebApi.VeteranSaleDirectory.Dto;

namespace WebApi.VeteranSaleDirectory
{
    public class VeteranSaleService: IVeteranSaleService
    {
        private readonly IVeteranSaleRepository _veteranSaleRepository;

        public VeteranSaleService(IVeteranSaleRepository veteranSaleRepository)
        {
            _veteranSaleRepository = veteranSaleRepository;
        }
        public async Task AddOffer(AddVeteranOffer newOffer, Guid id)
        {
            var user = await _veteranSaleRepository.GetUserById(id);
            var addOffer = new VeteranSale();
            addOffer.Id = Guid.NewGuid();
            addOffer.SaleName = newOffer.SaleName;
            addOffer.SaleDescription = newOffer.SaleDescription;
            addOffer.Lattitude = newOffer.Lattitude;
            addOffer.Longitude = newOffer.Longitude;
            addOffer.isActivated = true;
            addOffer.DateFrom = newOffer.DateFrom;
            addOffer.DateTo = newOffer.DateTo;
            addOffer.Discount = newOffer.Discount;
            addOffer.Veteran = (UserDirectory.Veteran)user;
            await _veteranSaleRepository.AddOffer(addOffer);

        }
        public async Task<List<GetVeteranOffers>> GetVeteranOffers()
        {
            var veteranOffers =  await _veteranSaleRepository.GetVeteranOffers();
            return veteranOffers.Select(veteranOffers => new GetVeteranOffers()
            {
                DateFrom = veteranOffers.DateFrom,
                DateTo = veteranOffers.DateTo,
                Discount = veteranOffers.Discount,
                Lattitude = veteranOffers.Lattitude,
                Longitude = veteranOffers.Longitude,
                SaleDescription = veteranOffers.SaleDescription,
                SaleName = veteranOffers.SaleName,
                LastName = _veteranSaleRepository.GetVeteranBySaleId(veteranOffers.Id).Result.FirstName,
                FirstName = _veteranSaleRepository.GetVeteranBySaleId(veteranOffers.Id).Result.LastName,
                Email = _veteranSaleRepository.GetVeteranBySaleId(veteranOffers.Id).Result.Email,
            }).ToList();



        }
    }
}
