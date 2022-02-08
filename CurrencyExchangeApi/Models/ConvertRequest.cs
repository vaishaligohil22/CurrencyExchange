using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Models
{
    public class ConvertRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Date { get; set; }
    }
}
