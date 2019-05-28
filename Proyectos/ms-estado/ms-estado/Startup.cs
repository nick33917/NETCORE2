﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Base_de_Datos.DB;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ms_estado.Negocio;
using MediatR;
using System.Reflection;

namespace ms_estado
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddDbContext<RRHHContext>
            (options => options.UseSqlServer(Configuration["BASE_DE_DATOS"]));

            services.AddTransient<INegocioEstado, NegocioEstado>();
            services.AddAutoMapper();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["SWAGGER:VERS"], new Info { Title = Configuration["SWAGGER:TITLE"], Version = Configuration["SWAGGER:VERS"] });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(Configuration["SWAGGER:JSON"], $"{Configuration["SWAGGER:TITLE"]} {Configuration["SWAGGER:VERS"]}");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}