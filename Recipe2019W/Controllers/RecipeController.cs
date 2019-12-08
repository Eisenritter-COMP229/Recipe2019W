using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe2019W.Models;
using Recipe2019W.Models.ViewModels;


namespace Recipe2019W.Controllers
{
    public class RecipeController:Controller
    {
        private IRecipeRepository repository;
        // How many items in each page
        public int PageSize = 4;

        //When RecipeController is called, repository will be created automatically, based on startup
        public RecipeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        // Send the recipes in the repository to the view
        public ViewResult List(int recipePage = 1) =>
            View(new RecipesListViewModel
                {
                    Recipes = repository.Recipes
                        .OrderBy(r => r.RecipeID)
                        // Skip Recipe by pageSize
                        .Skip((recipePage - 1) * PageSize)
                        //Take Number of Recipes
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = recipePage,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Recipes.Count()
                    }
                }
            );
    }
}
