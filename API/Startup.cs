using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Data;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44339",
                                "http://www.contoso.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });*/

            //services.AddMvc();

            services.AddControllers();
            services.AddDbContext<GiraAsesorContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GiraAsesor"))
            );

            services.AddTransient<IEstadosRepository, EstadoRepository>();
            services.AddTransient<ITipoGastoViajeRepository, TipoGastoViajeRepository>();
            services.AddTransient<ICategoriaTipoGastoViajeRepository, CategoriaTipoGastoViajeRepository>();
            services.AddTransient<IGastoViajeDetalleRepository, GastoViajeDetalleRepository>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IMaestroMonedaRepository, MaestroMonedaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
        }
    }
}
