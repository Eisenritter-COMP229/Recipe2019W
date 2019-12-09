using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public interface IRecipeIngredientRepository
    {
        IQueryable<RecipeIngredient> RecipeIngredients { get;}
        void SaveRecipeIngredient(RecipeIngredient recipeIngredient);
        RecipeIngredient DeleteRecipeIngredient(int recipeIngredientID);
    }
}
