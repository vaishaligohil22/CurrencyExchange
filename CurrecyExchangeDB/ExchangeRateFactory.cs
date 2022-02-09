using CurrecyExchangeDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrecyExchangeDB
{
    public interface IExchangeRateFactory
    {
        ExchangeRateContext Get();
        ExchangeRateContext ReadOnly();
    }

    public class ExchangeRateFactory : IExchangeRateFactory
    {
        private readonly DbContextOptions<ExchangeRateContext> _options;

        public ExchangeRateFactory(DbContextOptions<ExchangeRateContext> options)
        {
            _options = options;
        }

        public ExchangeRateContext Get() => new ExchangeRateContext(_options);

        public ExchangeRateContext ReadOnly()
        {
            var ctx = new ExchangeRateContext(_options);

            ctx.ChangeTracker.LazyLoadingEnabled = false;
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return ctx;
        }
    }
}
