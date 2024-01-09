
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace StockAndBuy.EF
{

    public class BundleContext : DbContext
    {
         //const string connectionString = "Data Source=.;Initial Catalog=StockAndBuyBundles;Trusted_Connection=True";

        public BundleContext() : base() { }

        public BundleContext(DbContextOptions<BundleContext> options) : base(options) { }

        public DbSet<Node> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BundleDB"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }



    }
}


