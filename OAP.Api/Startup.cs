using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OAPoliselo.Infra.Data.Context;
using Swashbuckle.Swagger;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.PlatformAbstractions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace OAP.Api
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
            //services.AddSwaggerGen(c => {

            //    c.SwaggerDoc("v1",
            //        new OpenApiInfo
            //        {
            //            Title = "OAPoliselo",
            //            Version = "v1",
            //            Description = "Exemplo de API REST criada com o ASP.NET Core 3.0 para consulta a indicadores econômicos",
            //            Contact = new OpenApiContact
            //            {
            //                Name = "Carlos Poliselo",
            //                Url = new Uri("https://github.com/renatogroffe")
            //            }
            //        });
            //});

            services.AddDbContext<SqlContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });

            services.AddSwaggerGen(c =>
            {
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Description = "Autenticação Bearer via JWT",
                //    Scheme = "Bearer"
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //    }
                //});

                //c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompreAgora API", Version = "v1", Description = "CompreAgora" });
                c.CustomSchemaIds(x => x.FullName);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    //var context = serviceScope.ServiceProvider.GetService<SqlContext>();
            //    //context.Database.Migrate();

            //    //try
            //    //{
            //    //    OAPoliselo.Infra.Data.DbInitializer.Initialize(context);
            //    //}
            //    //catch (Exception e)
            //    //{
            //    //    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //    //    logger.LogError("Um erro ocorreu no método seeding do contexto.");
            //    //}
            //}
            // ..

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("v1/swagger.json", "OAPoliselo V1");
            //});

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");
            //app.UseMvc();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompreAgora API - V1"); });
            //   .UseSwagger(x => x.RouteTemplate = "api-docs/{documentName}/swagger.json")
            //   .UseSwaggerUI(c =>
            //   {
            //       //c.OAuthClientId("foo-administration.swagger");
            //       c.RoutePrefix = "api-docs";
            //       c.SwaggerEndpoint("v1/swagger.json", "Foo Administration API");
            //   });

            //app.UseReDoc(options =>
            //{
            //    options.RoutePrefix = "api-docs-redoc";
            //    options.SpecUrl = "../api-docs/v1/swagger.json";
            //});
        }
    }
}
