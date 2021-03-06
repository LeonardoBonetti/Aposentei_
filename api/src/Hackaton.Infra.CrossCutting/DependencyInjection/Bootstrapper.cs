using AutoMapper;
using Hackaton.Application.AutoMapper;
using Hackaton.Application.Interfaces.Services;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Hackaton.CrossCutting.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void SetupIoC(this IServiceCollection services)
        {
            services.ConfigureAutoMapper();
            services.RegisterServices();
            services.AddRepositories();
        }
        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            services.AddAutoMapper(typeof(DomainToDTOMapProfile), typeof(DTOToDomainMapProfile));
        }
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrailService, TrailService>();
            services.AddScoped<ITrailTypeService, TrailTypeService>();
            services.AddScoped<IVideoTrailService, VideoTrailService>();
            services.AddScoped<ITextTrailService, TextTrailService>();
            services.AddScoped<IQuizTrailService, QuizTrailService>();
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITrailRepository, TrailRepository>();
            services.AddScoped<ITrailTypeRepository, TrailTypeRepository>();
            services.AddScoped<IVideoTrailRepository, VideoTrailRepository>();
            services.AddScoped<ITextTrailRepository, TextTrailRepository>();
            services.AddScoped<IQuizTrailRepository, QuizTrailRepository>();
        }
    }
}