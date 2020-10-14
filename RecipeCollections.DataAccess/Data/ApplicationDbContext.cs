using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RecipeCollections.Models;


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
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeCategory>().ToTable("RecipeCategories");

            modelBuilder.Entity<RecipeCategory>()
                .HasKey(c => new { c.RecipeId, c.CategoryId });
        }
    }
}
