﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //aggiorniamo un file per notificare al BrowserSync che deve aggiornare la pagina
                /// cancellato perchè non funziona
            }

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }


            
            

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();  *** questa istruzione che è stata remmata avrebbe consentito di svolgere tutto il lavoro esplicitato qui sotto *** 
            app.UseMvc(routebuilder =>
            {   
                //courses/detail/5
                routebuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
