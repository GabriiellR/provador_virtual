using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProvadorVirtual.Infraestrutura.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var connectionString = configuration.GetConnectionString("sqlServer");

            optionsBuilder.UseSqlServer(connectionString);
        }




    }
}