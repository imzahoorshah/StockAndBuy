 
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.Entity;

namespace StockAndBuy.EF
{

    public class BundleContext : DbContext
    { 

        public DbSet<Node> Nodes { get; set; }   
        public BundleContext()
            : base("MydbConn")
        {
            Database.SetInitializer<BundleContext>(new CreateDatabaseIfNotExists<BundleContext>()); 
        } 
    }
}


