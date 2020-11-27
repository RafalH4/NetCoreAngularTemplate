using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.BusinessRatingsDirectory.Dto;
using WebApi.UserDirectory;

namespace WebApi.BusinessRatingsDirectory
{
    public interface IBusinessRatingsRepository
    {
        Task<Veteran>GetVeteranById(Guid veteranID);
        Task<Business> GetBusinessById(Guid businessID);
        Task AddRate(BusinessRatings newRate);
        Task<IEnumerable<BusinessRatings>> GetBusinessRatings(Guid BusinessID);
    }
}
