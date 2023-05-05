using AutoMapper;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Mappers 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pagante, PaganteDTO>().ReverseMap();
        }
    }
}