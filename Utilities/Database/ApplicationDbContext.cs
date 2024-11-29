using Microsoft.EntityFrameworkCore;
using PaySummary_DayForce.Utilities.ConfigSettings;
using PaySummary_DayForce.Utilities.ConfigSettings.ConfigModels;

namespace PaySummary_DayForce.Utilities.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TimecardRecordTable> TimecardRecords { get; set; }
        public DbSet<RateTableRowTable> RateTableRows { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)  // Pass options to the base DbContext constructor
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigSettings.ConfigSettings.ConnectionString.DefaultConnection);
        }

        // Optionally, use OnModelCreating to configure the table names and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateTableRowTable>().ToTable("RateTableRows");
            modelBuilder.Entity<TimecardRecordTable>().ToTable("TimecardRecords");
        }
    }
}
