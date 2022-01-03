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
            //Aþaðýdaki IOC Container yapýsýný Autofac mimarisine taþýyacaðýz. Autofac bize AOP imkaný sunuyor.;
            //IOC Container altyapýsý sunan mimariler
            //Autofac, NÝnject, CastleWindsor, StructureMap, LightInh-ject, DryInject (Birbirinin alternatifi bunlar.) 

            services.AddControllers();

            //Web API'nin kendi içinde IOC Container yapýsý.
            //Biri senden ProductService isterse ona arkaplanda ProductManager oluþtur onu ver.
            //Kýsaca baðýmlýlýk görürsen bunu yap.
            //services.AddSingleton<IProductService, ProductManager>(); //Arkaplanda newleyip paketleyip constructora veriyor.
            //services.AddSingleton<IProductDal, EfProductDal>();

            //Web API Program.cs içinde yaptýk.
            //Kendi IOC yapýný kullanma benim bir IOC yapýlandýrmam var. Onu demememiz gerekiyor.

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
