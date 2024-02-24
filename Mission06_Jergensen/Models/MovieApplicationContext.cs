using Microsoft.EntityFrameworkCore;

namespace Mission06_Jergensen.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options) //Constructor
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            // modelBuilder.Entity<Categories>().HasData(
                // new Categories { CategoryId = 1, CategoryName = "Miscellaneous" },
                // new Categories { CategoryId = 2, CategoryName = "Drama" },
                // new Categories { CategoryId = 3, CategoryName = "Television" },
                // new Categories { CategoryId = 4, CategoryName = "Horror/Suspense" },
                // new Categories { CategoryId = 5, CategoryName = "Comedy" },
                // new Categories { CategoryId = 6, CategoryName = "Family" },
                // new Categories { CategoryId = 7, CategoryName = "Action/Adventure" },
                // new Categories { CategoryId = 8, CategoryName = "VHS" }
            // );
        //}
    }
}