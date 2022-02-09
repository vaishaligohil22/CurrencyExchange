using AutoMapper;
using CurrecyExchangeDB.Models;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;
using System;
using System.Collections.Generic;

namespace CurrencyExchangeApi.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var configuration = CreateConfiguration();
            return configuration.CreateMapper();
        }

        private static MapperConfiguration CreateConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                GeneralConfiguration(cfg);

                cfg.CreateMap(typeof(CurrecyExchangeDB.Collection<>), typeof(ApiCollection<>));

                cfg.CreateMap<ExchangeRateResponse, ConvertResponse>()
                    .ForMember(dest => dest.From, opts => opts.MapFrom(src => src.Base));
                
                cfg.CreateMap<ExchangeRateResponse, ExchangeRate>()
                    .ForMember(dest => dest.CurrFrom, opts => opts.MapFrom(src => src.Base))
                    .ForMember(dest => dest.CurrTo, opt => opt.MapFrom(src => src.Rates.Keys.ToString()))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                    .ReverseMap();

            });

            return configuration;
        }

        private static void GeneralConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.AllowNullCollections = true;
        }
    }
}
