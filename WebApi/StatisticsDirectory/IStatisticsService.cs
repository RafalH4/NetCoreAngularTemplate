using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.StatisticsDirectory.Dto;

namespace WebApi.StatisticsDirectory
{
    public interface IStatisticsService
    {
        Task<GetHomeStatisticsDto> GetHomeStatistics();
    }
}
