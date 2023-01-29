using Microsoft.EntityFrameworkCore;
using Model.Product;

namespace Data.Config
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }

        private string GetStringConection()
        {
            return "";
        }
    }
}
