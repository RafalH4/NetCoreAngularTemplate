using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BusinessDirectory
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Business>> GetBusinesses();
        Task<Business> GetBusiness(Guid id);
        Task AddBusiness(Business business);
    }
}
