using AutoMapper;
using Lab4WebApi.Models.DTO;
using Lab4WebApi.Models;

namespace Lab4WebApi.AutoMapper
{
    public class TariffProfile : Profile
    {
        public TariffProfile()
        {
            CreateMap<TariffCreateDTO, Tariff>();
            CreateMap<Tariff, TariffCreateDTO>();
        }
    }
}
