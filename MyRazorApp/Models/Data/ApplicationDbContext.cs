using Microsoft.EntityFrameworkCore;
using MyRazorApp.Models;

namespace MyRazorApp.Data{
    public class ApplicationDbContext : DbContext{
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext>: options) :base(options){

         }
         public DbSet<Category> Categories {get; set;}// This line use to create a  table in DB 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>.HasData(
            new Category {CategoryId = 1, nameof = "Action", DisplayOrder = 1},
            new Category {CategoryId = 2, nameof = "Adventure", DisplayOrder = 2},
            new Category {CategoryId = 3, nameof = "Comedy", DisplayOrder = 3},
        )
    }
    }
}