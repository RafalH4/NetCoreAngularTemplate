using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory.Dto;

namespace WebApi.BusinessDirectory
{
    public class BusinessService:IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task AddBusiness(AddBusinessDto addBusinessDto)
        {
            var business = new Business();
            business.Id = Guid.NewGuid();
            business.Address = addBusinessDto.Address;
            business.BusinessName = addBusinessDto.BusinessName;
            business.Lattitude = addBusinessDto.Lattitude;
            business.Category = addBusinessDto.Category;
            business.Longitude = addBusinessDto.Longitude;
            business.PhotoUrl = addBusinessDto.PhotoUrl;
            await _businessRepository.AddBusiness(business);
        }

        public async Task<GetBusinessDto> GetBusiness(Guid id)
        {
            var business = await _businessRepository.GetBusiness(id);
            return new GetBusinessDto()
            {
                Address = business.Address,
                BusinessName = business.BusinessName,
                Id = business.Id,
                Lattitude = business.Lattitude,
                Category = business.Category,
                Longitude = business.Longitude,
                PhotoUrl = business.PhotoUrl
            };
        }

        public async Task<IEnumerable<GetBusinessDto>> GetBusinessByCategory(Category c)
        {
            var x = await _businessRepository.GetBusinessByCategory(c);
            return x.Select(x => new GetBusinessDto()
            {
                Address = x.Address,
                BusinessName = x.BusinessName,
                Category = x.Category,
                Id = x.Id,
                Lattitude = x.Lattitude,
                Longitude = x.Longitude,
                PhotoUrl = x.PhotoUrl
            });
        }

        public async Task<IEnumerable<GetBusinessDto>> GetBusinesses()
        {
            var businesses = await _businessRepository.GetBusinesses();
            return businesses.Select(businesses => new GetBusinessDto()
            {
                Id = businesses.Id,
                BusinessName = businesses.Address,
                Address = businesses.Address,
                Lattitude = businesses.Lattitude,
                Category = businesses.Category,
                Longitude = businesses.Longitude,
                PhotoUrl = businesses.PhotoUrl
            });
        }
    }
}
