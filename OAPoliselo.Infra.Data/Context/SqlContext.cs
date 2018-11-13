using Microsoft.EntityFrameworkCore;
using OAPoliselo.Domain.Entities;
using OAPoliselo.Infra.Data.Mapping;

namespace OAPoliselo.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public SqlContext()
        {

        }
        public DbSet<SearchLog> SearchLog { get; set; }

        public DbSet<Dish> Dish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost;Database=OAPDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<DishType>().ToTable("DishType");
            modelBuilder.Entity<Period>().ToTable("Period");
            modelBuilder.Entity<SearchLog>().ToTable("SearchLog");
            modelBuilder.ApplyConfiguration(new DishMap());
            modelBuilder.ApplyConfiguration(new DishTypeMap());
            modelBuilder.ApplyConfiguration(new PeriodMap());
            modelBuilder.ApplyConfiguration(new SearchLogMap());

        }
    }
}
