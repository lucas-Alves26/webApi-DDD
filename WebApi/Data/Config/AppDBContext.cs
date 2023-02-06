using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Product;

namespace Data.Config
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("stringConnection"));
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }

        private string GetStringConection()
        {
            return "Server=MARRETA\\SQLEXPRESS;Database=webApi;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
