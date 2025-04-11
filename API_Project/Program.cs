
using System.Data;
using System.Security.Claims;
using System.Text;
using API_Project_BL;
using API_Project_DAL;
using API_Project_DAL.Context;
using API_Project_DAL.Models;
using API_Project_PL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddBusinessServices();

            builder.Services.AddDataAccesServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 2;
                options.User.RequireUniqueEmail = true;
            })
.AddEntityFrameworkStores<BugsContext>()
.AddDefaultTokenProviders();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
      .AddJwtBearer(options =>
      {
          options.SaveToken = true;
          options.RequireHttpsMetadata = false;
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidIssuer = builder.Configuration["JWT:IssuerIP"],

              ValidateAudience = true,
              ValidAudience = builder.Configuration["JWT:AudienceIP"],

              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"])),

              ValidateLifetime = true
          };
      });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    Constatnts.Policies.ForAdminOnly,
                    builder => builder
                        .RequireClaim(ClaimTypes.Role, "Manager", "Developer")
                        .RequireClaim(ClaimTypes.NameIdentifier)
                );

                options.AddPolicy(
                    Constatnts.Policies.ForDev,
                    builder => builder
                        .RequireClaim(ClaimTypes.Role, "Developer")
                        .RequireClaim(ClaimTypes.NameIdentifier)
                );
                options.AddPolicy(
                  Constatnts.Policies.ForTester,
                  builder => builder
                      .RequireClaim(ClaimTypes.Role, "Developer", "Tester")
                      .RequireClaim(ClaimTypes.NameIdentifier)
              );

            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("MyPolicy");


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
