using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.StatisticsDirectory.Dto;

namespace WebApi.StatisticsDirectory
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetHomeStatisticsDto> GetHomeStatistics()
        {

            return new GetHomeStatisticsDto()
            {
                ActualSales = await _statisticsRepository.GetActualSales(),
                ActualSalesWeek = await _statisticsRepository.GetActualSalesWeek(),
                Enterpreneurs = await _statisticsRepository.GetEnterpreneurs(),
                EnterpreneursWeek = await _statisticsRepository.GetEnterpreneursWeek(),
                Organizations = await _statisticsRepository.GetOrganizations(),
                //OrganizationsWeek = await _statisticsRepository.GetOrganizationsWeek(),
                Veterans = await _statisticsRepository.GetVeterans(),
                VeteransWeek = await _statisticsRepository.GetVeteransWeek()
            };
        }
    }
}
