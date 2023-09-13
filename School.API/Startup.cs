using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using School.API.Filters;
using School.Application.Services.Implementations;
using School.Application.Services.Interfaces;
using School.Application.Validators;
using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Domain.Interfaces.Services;
using School.Domain.Services;
using School.Infra.Data.Context;
using School.Infra.Data.Interfaces;
using School.Infra.Data.Repositories;
using System.Text;
using System.Text.Json.Serialization;

namespace School.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                   .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddProfessorInputModelValidator>())
                   .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //builder.Services.AddSingleton<SchoolDbContext>(); //Simular um banco de dados na memória
            services.AddDbContext<SchoolDbContext>(opt => opt.UseInMemoryDatabase("SchoolDB"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProfessorServiceApp, ProfessorServiceApp>();
            services.AddScoped<IProfessorDomainService, ProfessorDomainService>();
            services.AddScoped<IProfessorRepository<Professor>, ProfessorRepository>();
            services.AddScoped<IUserServiceApp, UserServiceApp>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IAuthDomainService, AuthDomainService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando o esquema Bearer."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
//       .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddProfessorInputModelValidator>())
//       .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

////builder.Services.AddSingleton<SchoolDbContext>(); //Simular um banco de dados na memória
//builder.Services.AddDbContext<SchoolDbContext>(opt => opt.UseInMemoryDatabase("SchoolDB"));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IProfessorServiceApp, ProfessorServiceApp>();
//builder.Services.AddScoped<IProfessorDomainService, ProfessorDomainService>();
//builder.Services.AddScoped<IProfessorRepository<Professor>, ProfessorRepository>();
//builder.Services.AddScoped<IUserServiceApp, UserServiceApp>();
//builder.Services.AddScoped<IUserDomainService, UserDomainService>();
//builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
//builder.Services.AddScoped<IAuthDomainService, AuthDomainService>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();