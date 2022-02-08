using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyExchangeApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;
        private readonly FixerApiClient _fixerClient;
        private readonly IMapper _mapper;

        public ConverterController(ILogger<ConverterController> logger, FixerApiClient fixerClient, IMapper mapper)
        {
            _logger = logger;
            _fixerClient = fixerClient;
            _mapper = mapper;
        }

        [HttpGet("latest")]
        public async Task<string> GetLatest([FromQuery]string from, [FromQuery]string to, [FromQuery] decimal amount)
        {
            var result = _mapper.Map<ConvertResponse>(await _fixerClient.GetAsync(from, to));

            var finalAmount = result.Rates[to.ToString()] * amount;

            return $"{from} to {to} for amount {amount} = {finalAmount}";
        }

        [HttpGet("historical")]
        public async Task<string> GetHistorical([FromQuery]string from, [FromQuery]string to, [FromQuery] decimal amount, [FromQuery]DateTime date)
        {
            var result = _mapper.Map<ConvertResponse>(await _fixerClient.GetAsync(from, to, date));

            var finalAmount = result.Rates[to.ToString()] * amount;

            return $"{from} to {to} for amount {amount} = {finalAmount}";
        }
    }
}