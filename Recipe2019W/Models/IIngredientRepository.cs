using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public interface IIngredientRepository
    {
        IQueryable<Ingredient> Ingredients { get; }
        void SaveIngredient (Ingredient ingredient);
        Ingredient DeleteIngredient(int ingredientID);
    }
}
