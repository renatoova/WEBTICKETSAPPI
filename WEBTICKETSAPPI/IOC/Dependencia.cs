using Microsoft.EntityFrameworkCore;
using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.Repositorio.Contratos;
using WEBTICKETSAPPI.Repositorio;
using WEBTICKETSAPPI.Services;
using WEBTICKETSAPPI.Services.Contratos;

namespace WEBTICKETSAPPI.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Cadena");
            service.AddDbContext<AtentodbContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            });
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<IAveriasServices, AveriasServices>();
            service.AddScoped<IUsuarioServices, UsuarioServices>();
            service.AddScoped<IRolServices, RolServices>();
        }
    }
}
