using System;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using Squader.IoC;
using Squader.Common;
using Squader.Common.Settings;
using Squader.Common.Extensions;
using Squader.Api.Areas.Authentication.Helpers;
using Microsoft.EntityFrameworkCore;
using Squader.Infrastructure.DAL;

namespace Squader.Api
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        private IContainer ApplicationContainer { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny",
                    x =>
                    {
                        x.AllowAnyOrigin();
                        x.AllowAnyMethod();
                        x.AllowAnyHeader();
                        x.AllowCredentials();
                    });
            });
            
            var jwtSettings = Configuration.GetSettings<JwtSettings>();

           
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        SaveSigninToken = true
                    };
                });
           // services.AddAuthorization(x => x.AddPolicy("admin", policy => policy.RequireRole("admin")));

            //change to autofac injection
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IEncrypter, Encrypter>();

            services.AddMvc();
            services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new Info
                    {
                        Title = "Squader",
                        Version = "v1"
                    });
                    x.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
                }
            );
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();


            return new AutofacServiceProvider(ApplicationContainer);


            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            ConfigureSerilog.Configure();
#if DEBUG
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("swagger/v1/swagger.json", "Squader");
                    x.RoutePrefix = "";
                });
#endif
            app.UseMvc();
        }
    }
}
