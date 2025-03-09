using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Hangfire;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Infrastructure.Auth;
using Infrastructure.Data;
using Infrastructure.Implementations.Hangfire;
using Infrastructure.Implementations.Repositories;
using Infrastructure.Implementations.Services;
using Infrastructure.Implementations.uOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("con");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryMapper, CategoryMapper>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieMapper, MovieMapper>();

            services.AddScoped<ISenderMessage, SendMessage>();

            services.AddScoped<IUserAuthentication, UserAuthentication>();

            var jwtOptions =configuration.GetSection("jwt").Get<JwtOptions>();
            services.AddSingleton<JwtOptions>(jwtOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issure,
                        ValidAudience = jwtOptions.Audiance,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.ApiKey))
                    };
                });

            return services;
        }
    }
}
