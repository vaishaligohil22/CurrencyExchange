using AutoMapper;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Services
{
    public interface IExchangeRateService
    {
        Task<Symbol> GetSymbolAsync();
        Task<ExchangeRateResponse> GetRateAsync(ExchangeRateRequest request);
    }

    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IFixerApiClient _fixerClient;
        private readonly IMapper _mapper;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(IFixerApiClient fixerClient, IMapper mapper, ILogger<ExchangeRateService> logger)
        {
            _fixerClient = fixerClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ExchangeRateResponse> GetRateAsync(ExchangeRateRequest request)
        {
            if(string.IsNullOrEmpty(request.From.ToString()) || string.IsNullOrEmpty(request.To.ToString()))
                return null;
            return _mapper.Map<ExchangeRateResponse>(await _fixerClient.GetAsync(request.From.ToString(), request.To.ToString(), request.Date));
        }

        public async Task<Symbol> GetSymbolAsync()
        {
            return await _fixerClient.GetAsync();
        }
    }
}
