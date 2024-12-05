using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13174.Data;
using WAD.BACKEND._13174.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD.BACKEND._13174.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            var existingRecipe = await _context.Recipes.FirstOrDefaultAsync(r => r.id == recipe.id);

            if (existingRecipe != null)
            {
                existingRecipe.Name = recipe.Name;
                existingRecipe.Description = recipe.Description;
                existingRecipe.Cuisine = recipe.Cuisine;
                existingRecipe.CreatedDate = recipe.CreatedDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.id == id);

            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
