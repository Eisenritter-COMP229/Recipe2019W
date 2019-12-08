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
    }
}
