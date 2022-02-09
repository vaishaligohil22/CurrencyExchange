using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CurrencyExchangeApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("GetSymbol")]
        public async Task<IActionResult> Get()
        {
            var result = await _exchangeRateService.GetSymbolAsync();
            return Ok(result);
        }

        [HttpGet("GetExchangeRate")]
        public async Task<IActionResult> GetExchangeRate([FromQuery]ExchangeRateRequest request)
        {
            var result = await _exchangeRateService.GetRateAsync(request);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Request is invalid");
        }
    }
}
