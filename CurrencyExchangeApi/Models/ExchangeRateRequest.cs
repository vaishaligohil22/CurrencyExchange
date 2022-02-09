using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class ExchangeRateRequest
    {
        [EnumDataType(typeof(CurrencyCode))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode From { get; set; }

        [EnumDataType(typeof(CurrencyCode))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode To { get; set; }
        public DateTime? Date { get; set; }
    }
}
