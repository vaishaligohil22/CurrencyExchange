using AutoMapper;
using CurrecyExchangeDB.Models;
using CurrecyExchangeDB.Repositories;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Services
{
    public interface IInternalService
    {
        Task<ExchangeRate> AddLatestAsync(ExchangeRateRequest request);
        Task<ApiCollection<ExchangeRate>> GetAllAsync(InternalRateRequest request);

        //Task<ApiCollection<Currency>> AddCurrency();
    }
    public class InternalService : IInternalService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<InternalService> _logger;
        private readonly IExchangeRateService _service;
        private readonly IExchangeRateRepository _exchangeRateRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public InternalService(IMapper mapper, ILogger<InternalService> logger, IExchangeRateService service,
                                    IExchangeRateRepository exchangeRateRepository, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
            _exchangeRateRepository = exchangeRateRepository;
            _currencyRepository = currencyRepository;

        }

        //public async Task<ApiCollection<Currency>> AddCurrency()
        //{
        //    var result = await _service.GetSymbolAsync();

        //    List<Currency> curr = new List<Currency>();

        //    if (result != null)
        //    {
        //        result.Symbols.ToList().ForEach(x => curr.Add(new Currency { Name = x.Key, Description = x.Value }));
        //    }

        //    var currencies = await _currencyRepository.AddAllAsync(curr);

        //    return _mapper.Map<ApiCollection<Currency>>(currencies);
        //}

        public async Task<ExchangeRate> AddLatestAsync(ExchangeRateRequest request)
        {
            var result = await _service.GetRateAsync(request);

            if (result != null)
            {
                var data = new ExchangeRate()
                {
                    CurrFrom = result.Base,
                    CurrTo = request.To.ToString(),
                    Date =  result.Date,
                    Rate = result.Rates[request.To.ToString()]
                };
                return await _exchangeRateRepository.AddAsync(data);
            }
               
            else
                return null;
        }

        public async Task<ApiCollection<ExchangeRate>> GetAllAsync(InternalRateRequest req)
        {
            return _mapper.Map<ApiCollection<ExchangeRate>>(
                await _exchangeRateRepository.GetAsync(req.From.ToString(), req.To.ToString(), req.FromDate, req.ToDate));
            
        }
    }
}
