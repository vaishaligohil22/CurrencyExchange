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
        public async Task<Symbol> Get()
        {
            return await _exchangeRateService.GetSymbolAsync();
        }

        [HttpGet("GetExchangeRate")]
        public async Task<ExchangeRateResponse> GetExchangeRate([FromQuery]ExchangeRateRequest request)
        {
            return await _exchangeRateService.GetRateAsync(request);
        }
    }
}
