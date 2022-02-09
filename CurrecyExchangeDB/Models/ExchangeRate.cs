using System;
using System.Collections.Generic;

#nullable disable

namespace CurrecyExchangeDB.Models
{
    public partial class ExchangeRate
    {
        public int Id { get; set; }
        public int CurrFrom { get; set; }
        public int CurrTo { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }

        public virtual Currency CurrFromNavigation { get; set; }
        public virtual Currency CurrToNavigation { get; set; }
    }
}
