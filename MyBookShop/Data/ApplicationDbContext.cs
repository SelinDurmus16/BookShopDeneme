using Microsoft.EntityFrameworkCore;
using MyBookShop.Models;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
namespace MyBookShop.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Category> Categories{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Horror", DisplayOrder= 1},
                new Category { Id = 2, Name = "Sci-fi", DisplayOrder = 2},
                new Category { Id = 3, Name = "Romance", DisplayOrder = 3},
                new Category { Id = 4, Name = "Action", DisplayOrder = 4},
                new Category { Id = 5, Name = "Thriller", DisplayOrder = 5}
            );
        }
    }
}
