using AutoMapper;
using Backend.DTOs;


namespace Backend.Mapping
{
    public class MappingProfile:Profile 
    {
        public MappingProfile()
        {
            CreateMap<NewsRequestDto, NewsHistory>().ReverseMap();
            CreateMap<NewsHistory,NewsResponseDto>().ReverseMap();      

        }
     


    }
}
