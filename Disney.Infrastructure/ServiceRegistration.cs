using System;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Data;
using Disney.Infrastructure.Repository;
using Disney.Infrastructure.Services;
using Disney.Infrastructure.Services.Interfaces;
using Disney.Infrastructure.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disney.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastrutureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:Conexion"));
            

            //Services
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IStorage, FileStorage>();
            services.AddScoped<IEmailService, SendEmailService>();
            //Repository
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            
            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            
        }
    }
}