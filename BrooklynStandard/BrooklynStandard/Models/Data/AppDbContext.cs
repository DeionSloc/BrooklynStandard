namespace BrooklynStandard.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
    public DbSet<UserRequest> UserRequest { get ; set; }
}