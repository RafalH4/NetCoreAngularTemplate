using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebApi.AwardDirectory;
using WebApi.BusinessDirectory;
using WebApi.BusinessRatingsDirectory;
using WebApi.DataContext;
using WebApi.EnterpreneurSaleDirectory;
using WebApi.GenerateData;
using WebApi.Helpers;
using WebApi.OrganizationDirectory;
using WebApi.UserDirectory;
using WebApi.VeteranAwardDirectory;
using WebApi.VeteranOrganizationDirectory;
using WebApi.VeteranSaleDirectory;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = Configuration.GetSection("AppSettings:DbConnection").Value;
            services.AddDbContext<Context>(opt =>
                opt.UseSqlServer(dbConnectionString));
            services.AddControllers();

            services.AddSwaggerGen(opt =>
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Api", Version = "v1" }));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(opt =>

             {
                 opt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("admin", policy => policy.RequireRole("admin"));
                opt.AddPolicy("client", policy => policy.RequireRole("client"));
            });


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IJwtHandler, JwtHandler>();

            services.AddScoped<IVeteranSaleService, VeteranSaleService>();
            services.AddScoped<IVeteranSaleRepository, VeteranSaleRepository>();

            services.AddScoped<IEnterpreneurSaleService, EnterpreneurSaleService>();
            services.AddScoped<IEnterpreneurSaleRepository, EnterpreneurSaleRepository>();

            services.AddScoped<IAwardService, AwardService>();
            services.AddScoped<IAwardRepository, AwardRepository>();

            services.AddScoped<IVeteranAwardService, VeteranAwardService>();
            services.AddScoped<IVeteranAwardRepository, VeteranAwardRepository>();

            services.AddScoped<IBusinessRatingsService, BusinessRatingsService>();
            services.AddScoped<IBusinessRatingsRepository, BusinessRatingsRepository>();

            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<IVeteranOrganizationRepository, VeteranOrganizationRepository>();
            services.AddScoped<IVeteranOrganizationService, VeteranOrganizationService>();

            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();

            services.AddScoped<IGenerateRepository, GenerateRepository>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }
            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1"));

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
