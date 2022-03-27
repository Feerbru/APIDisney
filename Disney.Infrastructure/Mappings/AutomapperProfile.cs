using AutoMapper;
using Disney.Core.DTOs.CharacterDtos;
using Disney.Core.DTOs.MovieDtos;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            //Character
            CreateMap<Character, CharacterOutDto>()
                .ReverseMap();
            CreateMap<CreationCharacterDto, Character>()
                .ReverseMap()
                .ForMember(x => x.Image, 
                    options => options.Ignore());
            CreateMap<CharacterDto, Character>()
                .ReverseMap();
            CreateMap<CharacterDto, CharacterOutDto>()
                .ReverseMap();
            CreateMap<CharacterOutDto, CreationCharacterDto>()
                .ReverseMap();
            
            //Movie
            CreateMap<Movie, MovieDto>()
                .ReverseMap();
            CreateMap<CreationMovieDto, Movie>()
                .ReverseMap()
                .ForMember(x => x.Image,
                    options => options.Ignore());
            CreateMap<Movie, MovieOutDto>()
                .ReverseMap();
            CreateMap<MovieDto, Movie>()
                .ReverseMap();
            CreateMap<MovieOutDto, CreationMovieDto>();
        }
    }
}