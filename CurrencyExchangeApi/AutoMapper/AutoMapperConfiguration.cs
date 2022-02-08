using AutoMapper;
using CurrencyExchangeApi.Clients;
using CurrencyExchangeApi.Models;

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
            var configuration = new MapperConfiguration(cfg => {
                GeneralConfiguration(cfg);

                cfg.CreateMap<ConvertResponse, Quote>().ReverseMap();
                cfg.CreateMap<ConvertResponse, Quote>().ReverseMap();

            });
            return configuration;
        }

        private static void GeneralConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.AllowNullCollections = true;
        }
    }
}
