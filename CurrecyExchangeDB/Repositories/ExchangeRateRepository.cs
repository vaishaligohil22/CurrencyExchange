using CurrecyExchangeDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrecyExchangeDB.Repositories
{
    public interface IExchangeRateRepository
    {
        Task<IEnumerable<ExchangeRate>> GetAsync(string from, string to, DateTime fromDate, DateTime toDate);
        Task<ExchangeRate> AddAsync(ExchangeRate exchangeRate);
    }

    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly IExchangeRateFactory _exchangeRateFactory;

        public ExchangeRateRepository(IExchangeRateFactory exchangeRateFactory)
        {
            _exchangeRateFactory = exchangeRateFactory;
        }

        public async Task<ExchangeRate> AddAsync(ExchangeRate exchangeRate)
        {
            using (var ctx = _exchangeRateFactory.Get())
            {
                await ctx.ExchangeRates.AddAsync(exchangeRate);
                await ctx.SaveChangesAsync();
            }
            return exchangeRate;
        }

        public async Task<IEnumerable<ExchangeRate>> GetAsync(string from, string to, DateTime fromDate, DateTime toDate)
        {
            using (var ctx = _exchangeRateFactory.ReadOnly())
            {
                var query = ctx.ExchangeRates.Where(
                                        (r) => r.CurrFrom == from
                                                && r.CurrTo == to
                                                && r.Date >= fromDate && r.Date <= toDate
                                       ).AsQueryable();

                return await query
                    .OrderByDescending(m => m.Id)
                    .ResultAsync();
            }
        }
    }
}
