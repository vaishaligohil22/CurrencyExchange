using System;
using System.Collections.Generic;

#nullable disable

namespace CurrecyExchangeDB.Models
{
    public partial class Currency
    {
        public Currency()
        {
            ExchangeRateCurrFromNavigations = new HashSet<ExchangeRate>();
            ExchangeRateCurrToNavigations = new HashSet<ExchangeRate>();
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExchangeRate> ExchangeRateCurrFromNavigations { get; set; }
        public virtual ICollection<ExchangeRate> ExchangeRateCurrToNavigations { get; set; }
    }
}
