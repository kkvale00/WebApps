using _11___EntityFrameworkEX.Data;
using _11___EntityFrameworkEX.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX
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
            //questa configurazione fa in modo di abilitare l'entity framework
            //con il database in memoria di prova
            //services.AddEntityFrameworkInMemoryDatabase();
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("SuperHeroes"));
            var dbAddress = "server=localhost;port=3306;database=superheroes;uid=root;password=root";
            services.AddDbContext<DataContext>(opt => opt.UseMySql(
                 //usemysql abilita il Db SQl,dobbiamo dargli l'indirizzo e la versione
                 //serverversion e il suo metodo vanno a controllare la versione
                    connectionString: dbAddress,
                    serverVersion: ServerVersion.AutoDetect(dbAddress)
                ));
            //aggiungo delle dependecies le nostri classi services
            //in modo che poi nel controller saremo in grado di farci
            //fornbire attraverso la DI, un oggetto (Singleton) dell'interface
            //dichiarata come <Primo Generic, Second Generic>();
            services.AddScoped<ISuperHeroService, SuperHeroService>();
            // i services chef anno uso del DataCOntext non devono essere agigunti
            // come singletone, bensi SCOPED, altrimenti il framework andra in eccezione
            // dato che nonpuo  fornire alla creazione di un singleton un oggetto(DataContext)
            // che a sua volta non viene creato come Singleton ma come Scoped
            // verra creato nel momento del bisogno, potrebbero pero esistere piu istanze di questo genere
            // va bene cosi perche EF non lavora su un DAO singleton, ma su quante sono le richiester
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
