using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.OrganizationDirectory.Dto;

namespace WebApi.OrganizationDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationController : ApiBaseController
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost("addOrganization")]
        public async Task<IActionResult> AddOrganization([FromBody] AddOrganization addOrganization)
        {
            await _organizationService.AddOrganization(addOrganization);
            return Ok();
        }
        [HttpGet("getAllOrganizations")]
        public async Task<IActionResult> GetOrganizations()
        {
            var organization = await _organizationService.GetOrganizations();
            return Ok(organization);
        }
    }
}
