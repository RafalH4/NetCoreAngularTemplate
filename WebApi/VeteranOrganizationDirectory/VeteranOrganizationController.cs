using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.VeteranOrganizationDirectory.Dto;

namespace WebApi.VeteranOrganizationDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class VeteranOrganizationController : ApiBaseController
    {
        private readonly IVeteranOrganizationService _veteranOrganizationService;
        public VeteranOrganizationController(IVeteranOrganizationService veteranOrganizationService)
        {
            _veteranOrganizationService = veteranOrganizationService;
        }
        [HttpPost("addVeteranToOrganization")]
        public async Task<IActionResult> AddVeteranToOrganization([FromBody] AddVeteranOrganization addVeteranOrganization)
        {
            await _veteranOrganizationService.AddVeteranToOrganization(addVeteranOrganization);
            return Ok();
        }
    }
}
