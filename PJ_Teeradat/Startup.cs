using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PJ_Teeradat.Models;

namespace PJ_Teeradat
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
            services.AddMvc();
            services.AddSession();

            services.AddApplicationInsightsTelemetry(Configuration);
            //var strConn = @"Server=10.0.0.228,1433; Initial Catalog = Drawmoney; User ID = Cs19; Password = 123456";
            //var strConn = @"Server=10.0.0.192,1433; Initial Catalog = Drawmoney; User ID = Cs19; Password = 123456";
            var strConn = @"Server=DESKTOP-E9T7UMB\TEERAPON;Database=Drawmoney;Trusted_Connection=True;";
            services.AddDbContext<DrawmoneyContext>(options => options.UseSqlServer(strConn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
