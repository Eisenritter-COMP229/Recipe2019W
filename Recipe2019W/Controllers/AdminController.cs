using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe2019W.Models;

namespace Recipe2019W.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Recipes);

        public ViewResult Edit(int recipeID) =>
            //Returns the first object in the collection that matches the query, if no match, null returned
            View(repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeID));

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult Create() => View("Edit", new Recipe());

        [HttpPost]
        public IActionResult Delete(int recipeID)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeID);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
