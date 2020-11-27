using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory.Dto;
using WebApi.Helpers;

namespace WebApi.AwardDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class AwardController : ApiBaseController
    {
        private readonly IAwardService _awardService;
        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        [HttpPost("addAward")]
        public async Task<IActionResult> AddAward([FromBody] AddAward addAward)
        {
            await _awardService.AddAward(addAward);
            return Ok();
        }
        [HttpGet("getAllAwards")]
        public async Task<IActionResult> GetAwards()
        {
            var award = await _awardService.GetAwards();
            return Ok(award);
        }
    }
}
