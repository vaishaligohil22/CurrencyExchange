
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;


namespace CurrencyExchangeApi.Models
{
    public class ConvertRequest
    {
        [Required]
        [EnumDataType(typeof(CurrencyCode))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode From { get; set; }

        [Required]
        [EnumDataType(typeof(CurrencyCode))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode To { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}
