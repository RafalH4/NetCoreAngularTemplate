using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.VeteranSaleDirectory.Dto;

namespace WebApi.VeteranSaleDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class VeteranSaleController : ApiBaseController
    {
        private readonly IVeteranSaleService _veteranSaleService;
        public VeteranSaleController(IVeteranSaleService veteranSaleService)
        {
            _veteranSaleService = veteranSaleService;
        }

        [HttpPost("addVeteranSale")]
        public async Task<IActionResult> AddVeteranSale([FromBody] AddVeteranOffer addOffer)
        {
            var id = CurrentUserId;
            await _veteranSaleService.AddOffer(addOffer, id);
            return Ok();
        }
        [HttpGet("getVeteranSales")]
        public async Task<IActionResult> getAllEnterpreneurSales()
        {
            var veteranSales = await _veteranSaleService.GetVeteranOffers();
            return Ok(veteranSales);
        }
    }
}
