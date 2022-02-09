using CurrecyExchangeDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrecyExchangeDB.Repositories
{
    public interface ICurrencyRepository
    {
        //Task<Collection<Currency>> AddAllAsync(IEnumerable<Currency> currencies);
    }
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IExchangeRateFactory _exchangeRateFactory;

        public CurrencyRepository(IExchangeRateFactory exchangeRateFactory)
        {
            _exchangeRateFactory = exchangeRateFactory;
        }

        //public async Task<Collection<Currency>> AddAllAsync(IEnumerable<Currency> currencies)
        //{
        //    using (var ctx = _exchangeRateFactory.Get())
        //    {
        //        await ctx.Currencies.AddRangeAsync(currencies);
        //        await ctx.SaveChangesAsync();

        //        return await ctx.Currencies.ResultAsync();
        //    }           
        //}
    }
}
