using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
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
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly FixerApiClient _fixerClient;
        private readonly IMapper _mapper;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, FixerApiClient fixerClient, IMapper mapper)
        {
            _logger = logger;
            _fixerClient = fixerClient;
            _mapper = mapper;
        }

        [HttpGet("symbol")]
        public async Task<Symbol> Get()
        {
            return await _fixerClient.GetAsync();
        }

        [HttpGet("latest")]
        public async Task<ConvertResponse> GetLatest([FromQuery]string from, [FromQuery]string to)
        {
            return _mapper.Map<ConvertResponse>(await _fixerClient.GetAsync(from, to));
        }

        [HttpGet("historical")]
        public async Task<ConvertResponse> GetHistorical([FromQuery]string from, [FromQuery]string to, [FromQuery]DateTime date)
        {
            return _mapper.Map<ConvertResponse>(await _fixerClient.GetAsync(from, to, date));
        }
    }
}
