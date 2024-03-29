using _06___DragonBallAPI.Services;
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

namespace _06___HunterxHunterAPI
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
            // Bisona abilitare l'utilizzo della CORS
            // Abilitare il Cross-Origin, cio� accettare anche chiamate
            // che arrivano da origini diverse
            services.AddCors(); // Vado ad aggiungere CORS ai services
            //services.AddSingleton<ScaffoldingCharacterService>();
            services.AddControllers();
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

            // Devo anche configurare da questa parte la CORS
            // Dicendo cosa accettare
            app.UseCors(
                options => options.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
            ); // Questa configurazione � abbastanza brutale
            // � permette l'accesso praticamente da qualsiasi origina
            // che utilizza qualsiasi metodo HTTP (GET/POST/PUT/DELETE)
            // Qualsiasi Header (Metadata delle chiamate)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
