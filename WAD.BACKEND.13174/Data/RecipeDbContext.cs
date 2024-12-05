using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13174.Models;

namespace WAD.BACKEND._13174.Data
{
    public class RecipeDbContext:DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
