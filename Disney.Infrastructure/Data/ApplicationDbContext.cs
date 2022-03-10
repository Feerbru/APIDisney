using Disney.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Disney.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Character> Character { get; set; }

        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        
        public class SampleDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

                var connString = @"Server=localhost;Database=DisneyDb;User Id=sa;Password=Password123;Trusted_Connection=False;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(connString);
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            new Movie.Mapping(modelBuilder.Entity<Movie>());
            base.OnModelCreating(modelBuilder);

        }
    }
}