using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM.API.Filters;
using DM.API.Handler;
using DM.API.IHandler;
using DM.API.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace DM.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string dmCors = "DmCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Extension method created to register the CORS
            services.ConfigureCors(dmCors);

            services.AddScoped<JwtFilter>();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DMFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IUser, UserHandler>();
            services.AddScoped<ICustomer, CustomerHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseExceptionHandler(config =>
            //{
            //    config.Run(async context =>
            //    {
            //        context.Response.StatusCode = 500;
            //        context.Response.ContentType = "application/json";

            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if (error != null)
            //        {
            //            var ex = error.Error;

            //            await context.Response.WriteAsync(new DmResponse()
            //            {
            //                ResponseCode = "500",
            //                ResponseBody = ex.Message
            //            }.ToString()); //ToString() is overridden to Serialize object
            //        }
            //    });
            //});

            app.UseCors(dmCors);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
