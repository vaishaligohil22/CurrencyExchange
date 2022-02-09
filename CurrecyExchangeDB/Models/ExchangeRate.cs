using System;
using System.Collections.Generic;

#nullable disable

namespace CurrecyExchangeDB.Models
{
    public partial class ExchangeRate
    {
        public int Id { get; set; }
        public string CurrFrom { get; set; }
        public string CurrTo { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
