using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.StatisticsDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ApiBaseController
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("getHomeStatistics")]
        public async Task<IActionResult> GetHomeStatistics()
        {
            var x = await _statisticsService.GetHomeStatistics();
            return Ok(x);
        }
    }
}
