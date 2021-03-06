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
    public interface IConvertService
    {
        Task<ConvertResponse> GetConcersionAsync(ConvertRequest request);
    }
    public class ConvertService : IConvertService
    {
        private readonly IFixerApiClient _fixerClient;
        private readonly IMapper _mapper;
        private readonly ILogger<ConvertService> _logger;

        public ConvertService(IFixerApiClient fixerClient, IMapper mapper, ILogger<ConvertService> logger)
        {
            _fixerClient = fixerClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ConvertResponse> GetConcersionAsync(ConvertRequest request)
        {
            var result = await _fixerClient.GetAsync(request.From.ToString(), request.To.ToString(), request.Date);

            var convertResponse = _mapper.Map<ConvertResponse>(result);

            if (result.Success)
            {
                convertResponse.To = request.To.ToString();
                convertResponse.Amount = request.Amount;
                convertResponse.Rate = result.Rates[request.To.ToString()];
                convertResponse.FinalAmount = result.Rates[request.To.ToString()] * request.Amount;
            }

            return convertResponse;
        }
    }
}
