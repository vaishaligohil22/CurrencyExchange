using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Clients
{
    public class Quote
    {
        public bool Success { get; set; }
        public bool Historical { get; set; }
        public string Timestamp { get; set; }
        public String Base { get; set; }
        public DateTime Date { get; set; }
        public IDictionary<string, decimal> Rates { get; set; }
    }

    public class Symbol
    {
        public bool Success { get; set; }
        public IDictionary<string, string> Symbols { get; set; }
    }
}
