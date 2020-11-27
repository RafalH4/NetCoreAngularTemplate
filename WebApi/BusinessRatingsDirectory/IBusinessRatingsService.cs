using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessRatingsDirectory.Dto;

namespace WebApi.BusinessRatingsDirectory
{
    public interface IBusinessRatingsService
    {
        Task AddBusinessRate(AddBusinessRate addBusinessRate, Guid veteranID);
        Task<IEnumerable<GetBusinessRatings>> GetBusinessRatings(Guid BusinessID);
    }
}
