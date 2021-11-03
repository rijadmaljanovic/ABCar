using ABCar.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABCar.WebApp
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
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<MojDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Lokalni1")));

            services.AddDistributedMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}


            app.UseSession();

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "area",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "default",
                    areaName: "Pocetna",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
