using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TS.Business.Concrete;
using TS.Business.Interfaces;
using TS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;
using TS.Web.CustomValidator;

namespace TS.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<ITurBilgileriService, TurBilgileriManager>();
            services.AddScoped<ITurBilgileriDal, EfTurBilgileriRepository>();
            services.AddScoped<IOtelBilgileriService, OtelBilgileriManager>();
            services.AddScoped<IOtelBilgileriDal, EfOtelBilgileriRepository>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderRepository>();
            services.AddScoped<IFavoriService, FavoriManager>();
            services.AddScoped<IFavoriDal, EfFavoriRepository>();
            services.AddScoped<IImagesService, ImagesManager>();
            services.AddScoped<IImagesDal, EfImagesRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IRezervasyonService, RezervasyonManager>();
            services.AddScoped<IRezervasyonDal, EfRezervasyonRepository>();
            services.AddScoped<IOtelService, OtelManager>();
            services.AddScoped<IOtelDal, EfOtelRepository>();
            services.AddScoped<IOtelOdaService, OtelOdaManager>();
            services.AddScoped<IOtelOdaDal, EfOtelOdaRepository>();
            services.AddScoped<IOtelOdaImageService, OtelOdaImageManager>();
            services.AddScoped<IOtelOdaImageDal, EfOtelOdaImageRepository>();
            services.AddScoped<IOtelImageService, OtelImageManager>();
            services.AddScoped<IOtelImageDal, EfOtelImageRepository>();
            services.AddScoped<IOtelFavoriService, OtelFavoriManager>();
            services.AddScoped<IOtelFavoriDal, EfOtelFavoriRepository>();
            services.AddScoped<IOtelOzellikService, OtelOzellikManager>();
            services.AddScoped<IOtelOzellikDal, EfOtelOzellikRepository>();
            services.AddScoped<IOtelOdaOzellikService, OtelOdaOzellikManager>();
            services.AddScoped<IOtelOdaOzellikDal, EfOtelOdaOzellikRepository>();
            services.AddScoped<IOtelRezervasyonService, OtelRezervasyonManager>();
            services.AddScoped<IOtelRezervasyonDal, EfOtelRezervasyonRepository>();
            services.AddScoped<IMesajService, MesajManager>();
            services.AddScoped<IMesajDal, EfMesajRepository>();   
            services.AddScoped<IOtelPuanDal, EfOtelPuanRepository>();
            services.AddScoped<IOtelPuanService, OtelPuanManager>();
            services.AddScoped<IAdminRezervasyonService, AdminRezervasyonManager>();
            services.AddScoped<IAdminRezervasyonDal, EfAdminRezervasyonRepository>();
            services.AddScoped<IOtelAdminRezervasyonService, OtelAdminRezervasyonManager>();
            services.AddScoped<IOtelAdminRezervasyonDal, EfOtelAdminRezervasyonRepository>();



            services.AddControllersWithViews();
            services.AddDbContext<TsContext>();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                //opt.Password.RequireDigit = false;
                //opt.Password.RequireUppercase = false;
                //opt.Password.RequiredLength = 1;
                //opt.Password.RequireLowercase = false;
                //opt.Password.RequireNonAlphanumeric = false;
            }).AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<TsContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "turizmseyehat";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Account/SignIn";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                     );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
