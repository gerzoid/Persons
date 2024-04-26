using Application.Common.Mapper;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Database.RepoDb;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepoDb;
using System.Globalization;
using System.Text;
using Web.Helpers;
using Web.Middleware;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            // Add services to the container.


            //Глобальная ауентификация
            /*builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings").Get<AppSettings>().Secret);                
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });*/
            string connectionString = builder.Configuration.GetConnectionString("PrimaryDbConnection");
            builder.Services.AddDbContext<PersonsDbContext>(options => { options.UseSqlServer(connectionString); } );

            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            

            #region RepoDb
            GlobalConfiguration.Setup().UseSqlServer();
            #endregion
            
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


            #region Maptser
            builder.Services.RegisterMapsterConfiguration();
            #endregion

            builder.Services.AddScoped<TablesService>();
            builder.Services.AddScoped<ITablesRepository, TablesRepository>();
            builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Global cors
            app.UseCors(x => x
              .SetIsOriginAllowed(origin => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
            
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
