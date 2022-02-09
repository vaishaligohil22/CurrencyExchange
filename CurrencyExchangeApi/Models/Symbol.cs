using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Models
{
    public class Symbol
    {
        public bool Success { get; set; }
        public IDictionary<string, string> Symbols { get; set; }
    }
}
