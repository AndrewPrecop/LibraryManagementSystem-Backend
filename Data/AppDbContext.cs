using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Person> People { get; set; }
        public  DbSet<Book> Books { get; set; }
        public DbSet<HistoricItem> Historic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Deleted)
                .HasDefaultValue(false);
        }
    }
    }