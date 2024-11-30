using AutoMapper;
using Lab4WebApi.Models;
using Lab4WebApi.Models.DTO;

namespace Lab4WebApi.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceCreateDTO, Service>();
            CreateMap<Service, ServiceCreateDTO>();
        }
    }
}
