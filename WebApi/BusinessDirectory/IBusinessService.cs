using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory.Dto;

namespace WebApi.BusinessDirectory
{
    public interface IBusinessService
    {
        Task<IEnumerable<GetBusinessDto>> GetBusinesses();
        Task<GetBusinessDto> GetBusiness(Guid id);
        Task AddBusiness(AddBusinessDto addBusinessDto);
    }
}
