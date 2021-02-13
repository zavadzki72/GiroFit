using ApplicationService.AutoMapper;
using ApplicationService.Interfaces;
using ApplicationService.Services;
using AutoMapper;
using CrossCutting.Bus;
using Data.PostgreSQL.Context;
using Data.PostgreSQL.Repositories;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Interfaces.PostgreSql.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.IoC {
    public static class NativeInjectorBootStrapper {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Mapper
            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutomapperConfig());
            });

            mapperConfig.AssertConfigurationIsValid();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // ApplicationService
            services.AddScoped<IUserApplicationService, UserApplicationService>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands

            //// Entity Framework Core
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(connectionString);
            });

            // Repositories - PgSQL
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateModuleRepository, TemplateModuleRepository>();
            services.AddScoped<ITemplateTrainRepository, TemplateTrainRepository>();
            services.AddScoped<ITemplateExerciseRepository, TemplateExerciseRepository>();

        }

    }
}
