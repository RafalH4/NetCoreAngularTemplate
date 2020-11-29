using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.StatisticsDirectory
{
    public interface IStatisticsRepository
    {
        Task<int> GetActualSales();
        Task<int> GetActualSalesWeek();
        Task<int> GetEnterpreneurs();
        Task<int> GetEnterpreneursWeek();
        Task<int> GetOrganizations();
        Task<int> GetOrganizationsWeek();
        Task<int> GetVeterans();
        Task<int> GetVeteransWeek();
    }
}
