using CatalogoDeJogos.Data.ContextDB;
using CatalogoDeJogos.Data.Repository;
using CatalogoDeJogos.Model.Interfaces.Repository;
using CatalogoDeJogos.Model.Interfaces.Service;
using CatalogoDeJogos.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoDeJogos.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // Context
            services.AddDbContext<Contexto>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Services
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IPlataformaService, PlataformaService>();


            // Repositorios
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
