using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RecipeCollections.Models;
using RecipeCollections.Models.Models;

namespace RecipeCollections.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Recipe> Recipes { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
