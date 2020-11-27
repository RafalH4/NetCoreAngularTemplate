using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.VeteranAwardDirectory.Dto;

namespace WebApi.VeteranAwardDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class VeteranAvardController : ApiBaseController
    {
        private readonly IVeteranAwardService _veteranAwardService;
        public VeteranAvardController(IVeteranAwardService veteranAwardService)
        {
            _veteranAwardService = veteranAwardService;
        }
        [HttpPost("addAwardToVeteran")]
        public async Task<IActionResult> AddVeteranAward([FromBody] AddVeteranAward addVeteranAward)
        {
            await _veteranAwardService.AddVeteranAward(addVeteranAward);
            return Ok();
        }

    }
}
