using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models.ViewModels
{
    public class RecipeIngredientViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Ingredient> Ingredients{ get; set; }
    }
}
