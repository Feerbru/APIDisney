using AutoMapper;
using Disney.Core.DTOs.CharacterDtos;
using Disney.Core.DTOs.MovieDtos;
using Disney.Core.DTOs.UserDto;
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
            CreateMap<MovieOutDto, CreationMovieDto>();
            
            //User
            CreateMap<User, UserDto>()
                .ReverseMap()
                .ForMember(x => x.Password, 
                    options => options.Ignore());
            
            CreateMap<User, UserLogin>()
                .ReverseMap()
                .ForMember(x => x.Password, 
                    options => options.Ignore());
        }
    }
}