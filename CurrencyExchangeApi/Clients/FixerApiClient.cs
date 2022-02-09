using CurrencyExchangeApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Clients
{
    public interface IFixerApiClient
    {
        Task<Symbol> GetAsync();
        Task<ExchangeRateResponse> GetAsync(string from, string to, DateTime? date);
    }

    public class FixerApiClient : IFixerApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public FixerApiClient(IConfiguration config, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://data.fixer.io/api/");
            _config = config;
        }

        public async Task<Symbol> GetAsync()
        {
            return JsonConvert.DeserializeObject<Symbol>(await Request(null, null, null));
        }
        
        public async Task<ExchangeRateResponse> GetAsync(string from, string to, DateTime? date)
        {
            return JsonConvert.DeserializeObject<ExchangeRateResponse>(await Request(date, from, to));
        }
        
        private string PrepareRequest(DateTime? date, string? from, string? to)
        {
            var pathString = from == null ? "symbols" : (date == null ? "latest" : date.Value.ToString("yyyy-MM-dd"));

            var queryString = $"{pathString}?access_key={_config.GetValue<string>("FixerApiSettings:ApiKey")}";

            if (from != null)
            {
                queryString += $"&base={from}";
            }

            if (to != null)
            {
                queryString += $"&symbols={string.Join(",", to)}";
            }

            return queryString;
        }

        private async Task<string> Request(DateTime? date, string? from, string? to)
        {
            var queryString = PrepareRequest(date, from, to);
            var response = await _httpClient.GetAsync(queryString);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception($"Request failed ({response.StatusCode})");
        }
    }
}
