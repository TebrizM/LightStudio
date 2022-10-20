using LightStudio.Core.Entities;
using LightStudio.Core;
using LightStudio.Helper.Implementations;
using LightStudio.Helper.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightStudio.Data;
using FluentValidation.AspNetCore;
using LightStudio.Helper.DTOs.CategoryDto;
using LightStudio_Version_1._0._0.ServiceExtentions;
using LightStudio.Helper.Profiles;

namespace LightStudio_Version_1._0._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<ISliderService, SliderService>();
    
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IAccountService, AccountService>();
                
            services.AddScoped<ISettingsService, SettingService>();
            
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IReklamService, ReklamService>();

           

            services.AddCors();

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();


            //            //builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
            //        });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Access-Control-Allow-Origin",
                    builder =>
                    {
                        //builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                        builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();

                        //builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidator>());
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LightStudio API",
                    Version = "v1",
                    Description = "An API to perform LightStudio operations",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Tabriz Mammadov",
                        Email = "code@code.edu.az",
                        Url = new Uri("https://code.az"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Tabriz",
                        Url = new Uri("https://code.az"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
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
                        new string[]{}
                    }
                });
            });

            services.AddAutoMapper(cnf =>
            {
                cnf.AddProfile(new MapProfiles());
            });

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = "https://localhost:5001/",
                    ValidAudience = "https://localhost:5001/",
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("241da6d5-5162-40de-ab6f-e619832d355c"))
                };
            });
        }


        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.ExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseCors("AllowOrigin");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProMusic API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
