using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public class EFIngredientRepository:IIngredientRepository
    {
        private ApplicationDBContext context;

        public EFIngredientRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Ingredient> Ingredients => context.Ingredients;

        public void SaveIngredient(Ingredient ingredient)
        {
            if (ingredient.IngredientID == 0)
            {
                context.Ingredients.Add(ingredient);
            }
            else
            {
                //Change Ingredient in collection
                Ingredient ingredientEntry = context.Ingredients
                    .FirstOrDefault(i => i.IngredientID == ingredient.IngredientID);
                //Extra Precaution in case entry is null
                if (ingredientEntry != null)
                {
                    ingredientEntry.Name = ingredient.Name;
                }
            }
            context.SaveChanges();
        }

        public Ingredient DeleteIngredient(int ingredientID)
        {
            Ingredient ingredientEntry = context.Ingredients
                .FirstOrDefault(i => i.IngredientID == ingredientID);
            if (ingredientEntry != null)
            {
                context.Ingredients.Remove(ingredientEntry);
                context.SaveChanges();
            }

            return ingredientEntry;
        }
    }
}
