using _07___GamestopAPI.Data;
using _07___GamestopAPI.Services;
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

namespace _07___GamestopAPI
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
            services.AddControllers();
            /*AddSingleton
             * sto dicendo al fw di inserire nelle dipendenze da fornire un oggetto
             * della classe DbContext e nello speicifico fornirlo come SIngleton
             * quando uno degli elementi creati attraverso il FW avra necessita di utilizzare
             * un elemento della classre DbContext gli verra fornito 
             * un singleton gestito dal FW
             */
            services.AddSingleton<DbContext>();
            /*aggiungiamo IVIDEOGAMESERVICE, essendo interfaccia
             * devo specificare la classe dell'implementazione da usare 
             */
            services.AddSingleton<IVideogameService, VideogameService>();
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
