using Application.Common.Mapper;
using Application.Services;
using Application.Services.Identity;
using Application.Services.Identity.Hashing;
using Application.Services.Identity.Interfaces;
using Application.Services.Identity.Tokens;
using Domain.Interfaces;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepoDb;
using TokenHandler = Application.Services.Identity.Tokens.TokenHandler;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            // Add services to the container.

            string connectionString = builder.Configuration.GetConnectionString("PrimaryDbConnection");
            builder.Services.AddDbContext<PersonsDbContext>(options => { options.UseSqlServer(connectionString); } );

            builder.Services.AddHttpContextAccessor();
            
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
            builder.Services.AddScoped<PersonsService>();
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
