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
using Microsoft.EntityFrameworkCore;
using Vendedores_MVC.Data;
using Vendedores_MVC.Service;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Vendedores_MVC
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
            services.AddControllersWithViews();

            services.AddDbContext<MyContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MyContext")));

            services.AddScoped<SeedingService>();
            services.AddTransient<VendedorService>();
            services.AddTransient<DepartamentoService>();
            services.AddTransient<RegistroDeVendaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            var ptBR = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(ptBR),
                SupportedCultures = new List<CultureInfo> { ptBR},
                SupportedUICultures = new List<CultureInfo> { ptBR}
            };
            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
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
