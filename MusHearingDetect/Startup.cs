using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MusHearingDetect.DbContexts;

namespace MusHearingDetect
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

            var connectionString = Configuration.GetConnectionString("MHDSysConnection");
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>((serviceProvider, options) =>
                options.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider)
                );
            var dbContextOptionsbuilder = new DbContextOptionsBuilder<UserContext>()

                .UseSqlServer(connectionString);
            services.AddSingleton(dbContextOptionsbuilder.Options);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    (_) => "To pole jest wymagane.");
            });
            services.AddDistributedMemoryCache(); 
            services.AddSession();
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  "Sing",
                  "Sing",
                  new { controller = "Test", action = "Sing" });

                routes.MapRoute(
                  "Questionnaire",
                  "Questionnaire",
                  new { controller = "Test", action = "Questionnaire" });

                routes.MapRoute(
                  "HomeAbout",
                  "About",
                  new { controller = "Home", action = "About" });

                routes.MapRoute(
                  "HomeIndex",
                  "Index",
                  new { controller = "Home", action = "Index" });

               


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
