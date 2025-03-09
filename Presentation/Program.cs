
using Application;
using Hangfire;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.MyCustomMiddlewares;
using Presentation.MyFilters;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<LogActionFilter>();//register filter for all Controllers
            }
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
           // builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(polcyOptions =>
                    polcyOptions
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                )
            );
            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddInfrastucture(builder.Configuration);

            // Add Swagger configuration.
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });

                // Add Bearer token security definition.
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by a space and your JWT token in the text input below.\nExample: \"Bearer your_token_here\""
                });

                // Add security requirement.
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<CustomMiddleware>();

            app.UseHttpsRedirection();

            app.UseCors();
            app.UseAuthorization();
            // Use Hangfire dashboard for monitoring
            //app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                DashboardTitle = "My Hangfire Dashboard"
            });
            
            app.MapControllers();

            app.Run();
        }
    }
}
