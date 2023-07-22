using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YilkarGida
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
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();

            services.AddMvc();

            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICategoryLanguageItemDAL, EFCategoryLanguageItemDAL>();
            services.AddScoped<ICategoryLanguageItemService, CategoryLanguageItemManager>();

            services.AddScoped<ILanguageDAL, EFLanguageDAL>();
            services.AddScoped<ILanguageService, LanguageManager>();

            services.AddScoped<IProductDAL, EFProductDAL>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IProductLanguageItemDAL, EFProductLanguageItemDAL>();
            services.AddScoped<IProductLanguageItemService, ProductLanguageItemManager>();

            services.AddScoped<ISubProductDAL, EFSubProductDAL>();
            services.AddScoped<ISubProductService, SubProductManager>();

            services.AddScoped<ISubProductLanguageItemDAL, EFSubProductLanguageItemDAL>();
            services.AddScoped<ISubProductLanguageItemService, SubProductLanguageItemManager>();

            services.AddScoped<IAboutDAL, EFAboutDAL>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IAboutLanguageItemDAL, EFAboutLanguageItemDAL>();
            services.AddScoped<IAboutLanguageItemService, AboutLanguageItemManager>();

            services.AddScoped<IContactDAL, EFContactDAL>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IContactLanguageItemDAL, EFContactLanguageItemDAL>();
            services.AddScoped<IContactLanguageItemService, ContactLanguageItemManager>();

            services.AddScoped<IContactMessageDAL, EFContactMessageDAL>();
            services.AddScoped<IContactMessageService, ContactMessageManager>();

            services.AddScoped<IEmployeeDAL, EFEmployeeDAL>();
            services.AddScoped<IEmployeeService, EmployeeManager>();

            services.AddScoped<IEmployeeLanguageItemDAL, EFEmployeeLanguageItemDAL>();
            services.AddScoped<IEmployeeLanguageItemService, EmployeeLanguageItemManager>();

            services.AddScoped<ISubcriberDAL, EFSubcriberDAL>();
            services.AddScoped<ISubcriberService, SubcriberManager>();

            services.AddScoped<IHomeDAL, EFHomeDAL>();
            services.AddScoped<IHomeService, HomeManager>();

            services.AddScoped<IHomeLanguageItemDAL, EFHomeLanguageItemDAL>();
            services.AddScoped<IHomeLanguageItemService, HomeLanguageItemManager>();

            services.AddScoped<IFooterDAL, EFFooterDAL>();
            services.AddScoped<IFooterService, FooterManager>();

            services.AddScoped<IFooterLanguageItemDAL, EFFooterLanguageItemDAL>();
            services.AddScoped<IFooterLanguageItemService, FooterLanguageItemManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Anasayfa}/{action=Index}/{id=1}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}