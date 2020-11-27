using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EnterpreneurSaleDirectory.Dto;
using WebApi.Helpers;

namespace WebApi.EnterpreneurSaleDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class EnterpreneurSaleController : ApiBaseController
    {
        private readonly IEnterpreneurSaleService _enterpreneurSaleService;
        public EnterpreneurSaleController(IEnterpreneurSaleService enterpreneurSaleService)
        {
            _enterpreneurSaleService = enterpreneurSaleService;
        }

        [HttpPost("addEnterpreneurSale")]
        public async Task<IActionResult> AddVeteranSale([FromBody] AddEnterpreneurOffer addOffer)
        {
            var id = CurrentUserId;
            await _enterpreneurSaleService.AddOffer(addOffer, id);
            return Ok();
        }
        [HttpGet("getEnterpreneurSales")]
        public async Task<IActionResult> getAllEnterpreneurSales()
        {
            var enterpreneurSales = await _enterpreneurSaleService.GetEnterpreneurOffers();
            return Ok(enterpreneurSales);
        }
        [HttpGet("getEnterpreneurSaleById/{id}")]
        public async Task<IActionResult> GetEnterpreneurSalesById(Guid id)
        {
            var enterpreneurSale = await _enterpreneurSaleService.GetEnterpreneurOffersById(id);
            return Ok(enterpreneurSale);
        }
    }
}
