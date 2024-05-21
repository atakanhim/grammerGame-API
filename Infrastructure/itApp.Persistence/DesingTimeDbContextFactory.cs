
using grammerGame.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace grammerGame.Persistence
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<GrammerGameDbContext>
    {
        public GrammerGameDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GrammerGameDbContext>();

            // appsettings.json dosyasından configuration ayarlarını okumak için
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MsSQL");

            optionsBuilder.UseSqlServer(connectionString);

            return new GrammerGameDbContext(optionsBuilder.Options);
        }
    }
}
