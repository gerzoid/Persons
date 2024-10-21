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
            builder.Services.AddDbContext<PersonsDbContext>(options => { options.UseSqlServer(connectionString); });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();


            #region RepoDb
            GlobalConfiguration.Setup().UseSqlServer();
            #endregion

            builder.Services.AddSwaggerGen(cfg =>
            {
                cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JSON Web Token to access resources. Example: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    new [] { string.Empty }
                }
            });
            });

            #region Maptser
            builder.Services.RegisterMapsterConfiguration();
            #endregion

            builder.Services.AddScoped<TablesService>();
            builder.Services.AddScoped<PersonsService>();
            builder.Services.AddScoped<ExportsService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ITablesRepository, TablesRepository>();
            builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();

            #region Identity

            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddSingleton<ITokenHandler, TokenHandler>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
            builder.Services.AddSingleton(signingConfigurations);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
                    new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.SecurityKey,
                        ClockSkew = TimeSpan.Zero
                    };
            });

            #endregion



            //builder.Services.AddScoped<IIdentityService, IdentityService>();


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
            //app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
