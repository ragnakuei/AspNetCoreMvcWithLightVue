using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcWithLightVue.Repositories;

namespace AspNetCoreMvcWithLightVue
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
            services.AddControllersWithViews()
                    .AddJsonOptions(options =>
                                    {
                                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                                        options.JsonSerializerOptions.IgnoreNullValues     = true;
                                    });

            services.AddScoped<SqlConnection>(serviceProvider =>
                                              {
                                                  var connectionString = Configuration.GetConnectionString("DefaultConnection");

                                                  return new SqlConnection(connectionString);
                                              });
            services.AddScoped<NorthwindRepository>();

            services.AddSession();
            services.AddHttpContextAccessor();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
                               {
                                   ServeUnknownFileTypes = true
                               });
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllerRoute(
                                                              name: "default",
                                                              pattern: "{controller=Home}/{action=Index}/{id?}");
                             });
        }
    }
}
