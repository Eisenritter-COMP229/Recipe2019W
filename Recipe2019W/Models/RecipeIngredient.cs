using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public class RecipeIngredient
    {
        [BindNever]
        public int RecipeIngredientID { get; set; }

        [BindNever]
        public ICollection<IngredientLine> Lines { get; set; }

        public int RecipeID { get; set; }
    }
}
