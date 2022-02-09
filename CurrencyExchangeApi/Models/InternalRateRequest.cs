using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Models
{
    public class InternalRateRequest
    {
        public CurrencyCode From { get; set; }
        public CurrencyCode To { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
