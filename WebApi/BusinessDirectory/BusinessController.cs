using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory.Dto;
using WebApi.Helpers;

namespace WebApi.BusinessDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessController : ApiBaseController
    {
        private readonly IBusinessService _businessService;
        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }
        [HttpGet("getBusinesses")]
        public async Task<IActionResult> GetBusinesses()
        {
            var businesses = await _businessService.GetBusinesses();
            return Ok(businesses);
        }
        [HttpGet("getBusiness/{id}")]
        public async Task<IActionResult> GetBusiness(Guid id)
        {
            var business = await _businessService.GetBusiness(id);
            return Ok(business);
        }
        [HttpGet("getBusinessByCategory/{cat}")]
        public async Task<IActionResult> GetBusinessByCategory(Category cat)
        {
            var business = await _businessService.GetBusinessByCategory(cat);
            return Ok(business);
        }
        [HttpPost("addBusiness")]
        public async Task<IActionResult> AddBusiness([FromBody] AddBusinessDto addBusinessDto)
        {
            await _businessService.AddBusiness(addBusinessDto);
            return Ok();
        }
    }
}
