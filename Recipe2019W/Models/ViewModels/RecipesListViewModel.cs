using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe2019W.Models;

namespace Recipe2019W.Models.ViewModels
{
    public class RecipesListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
