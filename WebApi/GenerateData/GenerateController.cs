using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.GenerateData
{
    [Route("[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly IGenerateRepository _generateRepository;
        public GenerateController(IGenerateRepository generateRepository)
        {
            _generateRepository = generateRepository;
        }
        [HttpPost("GenerateData")]
        public async Task<IActionResult> GenerateData()
        {
            await _generateRepository.GenerateData();
            return Ok();
        }
    }
}
