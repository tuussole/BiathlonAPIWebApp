using Microsoft.EntityFrameworkCore;

namespace BiathlonAPIWebApp.Models
{
    public class BiathlonAPIContext: DbContext
    {
        public BiathlonAPIContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Cup> Cups { get; set; }
        public virtual DbSet<Prize> Prizes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<BiathlonistCupPrize> BiathlonistCupPrizes { get; set; }
        public virtual DbSet<Biathlonist> Biathlonists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=password");


    }
}
