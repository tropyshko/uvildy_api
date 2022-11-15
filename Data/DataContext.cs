using Microsoft.EntityFrameworkCore;

namespace api_net.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Reserve> Reserves { get; set; }


    }
}
