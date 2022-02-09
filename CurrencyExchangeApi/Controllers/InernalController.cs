using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchangeApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InernalController : ControllerBase
    {
        private readonly IInternalService _internalService;

        public InernalController(IInternalService internalService)
        {
            _internalService = internalService;
        }

        //[HttpPost("AddCurrency")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public async Task<IActionResult> AddCurrency()
        //{
        //    var result = await _internalService.AddCurrency();
        //    return Ok(result);
        //}

        [HttpPost("AddLatest")]
        public async Task<IActionResult> AddLatest([FromBody]ExchangeRateRequest request)
        {
            var result = await _internalService.AddLatestAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetExchangeRate([FromQuery]ExchangeRateRequest request)
        {
            var result = await _internalService.GeAsync(request);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Request is invalid");
        }
    }
}