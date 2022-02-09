using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Models
{
    public class ConvertResponse
    {
        public bool Success { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
