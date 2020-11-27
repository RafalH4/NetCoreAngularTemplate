using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessRatingsDirectory.Dto;
using WebApi.Helpers;

namespace WebApi.BusinessRatingsDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessRatingsController : ApiBaseController
    {
        private readonly IBusinessRatingsService _businessRatingsService;
        public BusinessRatingsController(IBusinessRatingsService businessRatingsService)
        {
            _businessRatingsService = businessRatingsService;
        }

        [HttpPost("addRateTuBusiness")]
        public async Task<IActionResult> AddBusinessRate([FromBody] AddBusinessRate addBusinessRate)
        {
            var veteranID = CurrentUserId;
            await _businessRatingsService.AddBusinessRate(addBusinessRate, veteranID);
            return Ok();
        }
        [HttpGet("getBusinessRatingsById/{id}")]
        public async Task<IActionResult> GetBusinessRatings(Guid id)
        {
            var result = await _businessRatingsService.GetBusinessRatings(id);
            return Ok(result);
        }

    }
}
