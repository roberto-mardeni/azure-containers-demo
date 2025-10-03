using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using aspnet_core_dotnet_core.Services;

namespace aspnet_core_dotnet_core
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class with the specified configuration.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <param name="configuration">The application configuration properties.</param>
        /// The <see cref="IServiceCollection"/> to which services are added.
        /// </param>
        /// <remarks>
        /// <para>
        /// - Configures cookie policy options, enforcing user consent for non-essential cookies and setting the minimum SameSite policy.
        /// - Registers <see cref="IApplicationConfiguration"/> as a singleton, binding its values from the "ApplicationConfiguration" section in configuration.
        /// - Adds support for Razor Pages to the application.
        /// </para>
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>(
                e => Configuration.GetSection("ApplicationConfiguration")
                    .Get<ApplicationConfiguration>());

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
            }

            // Add custom middleware to append an HTTP header
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    if (!context.Response.Headers.ContainsKey(key: "X-Custom-Header"))
                    {
                        context.Response.Headers.Append("X-Custom-Header", "SampleApp-" + DateTime.Now.ToString("s"));
                    }

                    return Task.CompletedTask;
                });

                await next();
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
