using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.BusinessRatingsDirectory.Dto;
using WebApi.UserDirectory;

namespace WebApi.BusinessRatingsDirectory
{
    public class BusinessRatingsService : IBusinessRatingsService
    {
        private readonly IBusinessRatingsRepository _businessRatingsRepository;
        public BusinessRatingsService(IBusinessRatingsRepository businessRatingsRepository)
        {
            _businessRatingsRepository = businessRatingsRepository;
        }
        public async Task AddBusinessRate(AddBusinessRate addBusinessRate, Guid veteranID)
        {
            var veteran =   _businessRatingsRepository.GetVeteranById(veteranID).Result;
            var business =  _businessRatingsRepository.GetBusinessById(addBusinessRate.BusinessID).Result;
            var newRate = new BusinessRatings();

            newRate.Business = business;
            newRate.Veteran = veteran;
            newRate.Id = Guid.NewGuid();
            newRate.Opinion = addBusinessRate.Opinion;
            newRate.Rate = addBusinessRate.Rate;
            newRate.UrlPhoto = addBusinessRate.UrlPhoto;
            await _businessRatingsRepository.AddRate(newRate);
        }

        public async Task<IEnumerable<GetBusinessRatings>> GetBusinessRatings(Guid BusinessID)
        {
            var x = await _businessRatingsRepository.GetBusinessRatings(BusinessID);

            return x.Select(x => new GetBusinessRatings()
            {
                Id = x.Id,
                Opinion = x.Opinion,
                Rate = x.Rate,
                UrlPhoto = x.UrlPhoto,
                Veteran = new VeteranDto()
                {
                    AwatarUrl = x.Veteran.AwatarUrl,
                    FirstName = x.Veteran.FirstName,
                    Id= x.Veteran.Id,
                    LastName = x.Veteran.LastName
                }
            });

        }
    }
}
