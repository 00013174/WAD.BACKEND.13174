using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13174.Data;
using WAD.BACKEND._13174.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD.BACKEND._13174.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeDbContext _context;

        public IngredientRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients
                                 .Include(i => i.Recipe) 
                                 .ToListAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _context.Ingredients
                                 .Include(i => i.Recipe) 
                                 .FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            var recipe = await _context.Recipes.FindAsync(ingredient.RecipeId);
            if (recipe == null)
            {
                throw new KeyNotFoundException("Invalid RecipeId. The recipe does not exist.");
            }

            ingredient.Recipe = recipe; 
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            var existingIngredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.id == ingredient.id);

            if (existingIngredient != null)
            {
                existingIngredient.Name = ingredient.Name;
                existingIngredient.Quantity = ingredient.Quantity;
                existingIngredient.RecipeId = ingredient.id;

                var recipe = await _context.Recipes.FindAsync(ingredient.RecipeId);
                if (recipe == null)
                {
                    throw new KeyNotFoundException("Invalid RecipeId. The recipe does not exist.");
                }

                existingIngredient.Recipe = recipe;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
