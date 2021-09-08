using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CatalogoDeJogos.Data.ContextDB
{
    public class ContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CatalogoDeJogos.API"))
                                .AddJsonFile("appsettings.Development.json")
                                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<Contexto>();
            var connectionString = configuration.GetConnectionString("SQL");
            dbContextBuilder.UseSqlServer(connectionString);

            return new Contexto(dbContextBuilder.Options);
        }
    }
}
