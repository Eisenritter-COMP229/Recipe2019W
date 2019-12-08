using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public class EFRecipeRepository:IRecipeRepository
    {
        private ApplicationDBContext context;

        // Whenever EFRecipeRepository is created sets the context to the context
        public EFRecipeRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        // The Recipes are set to the Recipes in the database
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID== 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                //Change product in collection
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeID == recipe.RecipeID);
                //Extra Precaustion
                if (recipeEntry != null)
                {
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Description = recipe.Description;
                    recipeEntry.Type = recipe.Type;
                    recipeEntry.NumOfServings = recipe.NumOfServings;
                    recipeEntry.PrepTime = recipe.PrepTime;
                    recipeEntry.TotalTime = recipe.TotalTime;
                }
            }

            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeId);
            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }
    }


}
