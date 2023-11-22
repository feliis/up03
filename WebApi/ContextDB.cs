using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ContextDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VinylStore;Username=postgres;Password=5689");
        }

        public ContextDB()
        {
            Database.EnsureCreated();
        }


        public DbSet<Sale> sale { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Vinyl_Record> vinyl_record { get; set; }
        public DbSet<Style> style { get; set; }
        public DbSet<Style> style_record { get; set; }
        public DbSet<Type_plate> type { get; set; }
        public DbSet<Condition> condition { get; set; }
        public DbSet<Artist> artist { get; set; }
        public DbSet<Label> label { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Album> album { get; set; }


    }

}
