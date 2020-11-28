using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.StatisticsDirectory
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;
        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public async Task<int> GetActualSales()
            => await Task.FromResult(_context.EnterpreneurSales.Where(s => s.DateTo >= DateTime.Now).ToList().Count());

        public async Task<int> GetActualSalesWeek()
            => await Task.FromResult(_context.EnterpreneurSales.Where(s => s.DateTo >= DateTime.Now && s.DateFrom.AddDays(7) <= DateTime.Now).ToList().Count());

        public async Task<int> GetEnterpreneurs()
            => await Task.FromResult(_context.Enterpreneurs.Where(s => s.IsActive == true).ToList().Count());

        public async Task<int> GetEnterpreneursWeek()
            => await Task.FromResult(_context.Enterpreneurs.Where(s => s.IsActive == true && s.CreatedAt.AddDays(7) <= DateTime.Now).ToList().Count());

        public async Task<int> GetOrganizations()
            => await Task.FromResult(_context.Organizations.ToList().Count());

        public async Task<int> GetOrganizationsWeek()
            => await Task.FromResult(_context.Organizations.ToList().Count());
        //dodac date

        public async Task<int> GetVeterans()
            => await Task.FromResult(_context.Veterans.ToList().Count());

        public async Task<int> GetVeteransWeek()
            => await Task.FromResult(_context.Veterans.Where(s=>s.CreatedAt.AddDays(7) <= DateTime.Now).ToList().Count());
    }
}
