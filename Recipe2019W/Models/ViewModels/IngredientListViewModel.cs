using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models.ViewModels
{
    public class IngredientListViewModel
    {
        public IEnumerable<Ingredient> Ingredients{ get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
