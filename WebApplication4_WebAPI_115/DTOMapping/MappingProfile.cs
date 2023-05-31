using AutoMapper;
using WebApplication4_WebAPI_115.Models;
using WebApplication4_WebAPI_115.Models.DTOs;

namespace WebApplication4_WebAPI_115.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalParkDto, NationalPark>().ReverseMap();
            CreateMap<TrailDto, Trail>().ReverseMap();
        }
    }
}
