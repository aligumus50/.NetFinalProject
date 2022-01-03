using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            //A�a��daki IOC Container yap�s�n� Autofac mimarisine ta��yaca��z. Autofac bize AOP imkan� sunuyor.;
            //IOC Container altyap�s� sunan mimariler
            //Autofac, N�nject, CastleWindsor, StructureMap, LightInh-ject, DryInject (Birbirinin alternatifi bunlar.) 

            services.AddControllers();

            //Web API'nin kendi i�inde IOC Container yap�s�.
            //Biri senden ProductService isterse ona arkaplanda ProductManager olu�tur onu ver.
            //K�saca ba��ml�l�k g�r�rsen bunu yap.
            //services.AddSingleton<IProductService, ProductManager>(); //Arkaplanda newleyip paketleyip constructora veriyor.
            //services.AddSingleton<IProductDal, EfProductDal>();

            //Web API Program.cs i�inde yapt�k.
            //Kendi IOC yap�n� kullanma benim bir IOC yap�land�rmam var. Onu demememiz gerekiyor.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
