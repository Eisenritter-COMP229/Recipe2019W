using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    //public class EFRecipeIngredientRepository:IRecipeIngredientRepository
    //{
    //    private ApplicationDBContext context;

    //    public EFRecipeIngredientRepository(ApplicationDBContext ctx)
    //    {
    //        context = ctx;
    //    }

    //    public IQueryable<RecipeIngredient> RecipeIngredients => context.RecipeIngredients;

    //    public void SaveRecipeIngredient(RecipeIngredient recipeIngredient)
    //    {
    //        if (recipeIngredient.RecipeIngredientID == 0)
    //        {
    //            context.RecipeIngredients.Add(recipeIngredient);
    //        }
    //        else
    //        {
    //            //Change Ingredient in collection
    //            RecipeIngredient recipeIngredientEntry = context.RecipeIngredients
    //                .FirstOrDefault(i => i.RecipeIngredientID == recipeIngredient.RecipeIngredientID);
    //        }
    //        context.SaveChanges();
    //    }

    //    public RecipeIngredient DeleteRecipeIngredient(int recipeIngredientID)
    //    {
    //        RecipeIngredient recipeIngredientEntry = context.RecipeIngredients
    //            .FirstOrDefault(i => i.RecipeIngredientID == recipeIngredientID);
    //        if (recipeIngredientEntry != null)
    //        {
    //            context.RecipeIngredients.Remove(recipeIngredientEntry);
    //            context.SaveChanges();
    //        }

    //        return recipeIngredientEntry;
    //    }
    //}
}
