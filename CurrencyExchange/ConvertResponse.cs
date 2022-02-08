using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.Models
{
    public class ConvertResponse
    {
        public bool Success { get; set; }
        public bool Historical { get; set; }
        public string Timestamp { get; set; }
        public String Base { get; set; }
        public DateTime Date { get; set; }
        public IDictionary<string, decimal> Rates { get; set; }
    }
}
