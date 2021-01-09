using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Repository;
using EcommerceApp.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EcommerceApp
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();

            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<ISlideShowRepository, SlideShowRepository>();
            services.AddTransient<ISlideShowManager, SlideShowManager>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryManager, CategoryManager>();

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandManager, BrandManager>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductManager, ProductManager>();

            services.AddTransient<IProductPhotoRepository, ProductPhotoRepository>();
            services.AddTransient<IProductPhotoManager, ProductPhotoManager>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountManager, AccountManager>();

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleManager, RoleManager>();

            services.AddTransient<IRoleAccountRepository, RoleAccountRepository>();
            services.AddTransient<IRoleAccountManager, RoleAccountManager>();
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
            app.UseStaticFiles();

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
