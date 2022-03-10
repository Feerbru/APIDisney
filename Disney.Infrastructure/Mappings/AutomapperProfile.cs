using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Character, CharacterDTO>()
                .ReverseMap();
            CreateMap<CreationCharacterDto, Character>()
                .ReverseMap()
                .ForMember(x => x.Image, options => options.Ignore());
            CreateMap<CharacterOutDTO, Character>()
                .ReverseMap();
            CreateMap<CharacterOutDTO, CharacterDTO>()
                .ReverseMap();
            CreateMap<CharacterDTO, CreationCharacterDto>()
                .ReverseMap();
            CreateMap<Movie, MovieDto>()
                .ReverseMap();
        }
    }
}