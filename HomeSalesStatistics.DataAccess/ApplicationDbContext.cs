using HomeSalesStatistics.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeSalesStatistics.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HouseSaleOffer> HouseSaleOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString =
                "Data Source=DESKTOP-9V4Q8BS;Initial Catalog=HomeSaleOffers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            options.UseSqlServer(connectionString);
        }
    }
}
