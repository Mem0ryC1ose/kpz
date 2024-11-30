using AutoMapper;
using Lab4WebApi.Models;
using Lab4WebApi.Models.DTO;

namespace Lab4WebApi.AutoMapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientCreateDTO, Client>();
        }
        
    }
}
