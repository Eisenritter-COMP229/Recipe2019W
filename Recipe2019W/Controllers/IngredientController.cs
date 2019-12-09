using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe2019W.Models;
using Recipe2019W.Models.ViewModels;

namespace Recipe2019W.Controllers
{
    public class IngredientController:Controller
    {
        private IIngredientRepository repository;
        public int PageSize = 10;

        public IngredientController(IIngredientRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int ingredientPage = 1) =>
            View(new IngredientListViewModel
            {
                Ingredients = repository.Ingredients
                    .OrderBy(r => r.IngredientID)
                    .Skip((ingredientPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = ingredientPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Ingredients
                        .Count()
                }
            });

        [HttpPost]
        public IActionResult Edit(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                repository.SaveIngredient(ingredient);
                TempData["message"] = $"{ingredient.Name} has been saved!";
                return RedirectToAction(nameof(List),"Ingredient");
            }
            else
            {
                return View(ingredient);
            }
        }

        public ViewResult Create() => View("Edit", new Ingredient());

        [HttpPost]
        public IActionResult Delete(int ingredientId)
        {
            Ingredient deletedIngredient = repository.DeleteIngredient(ingredientId);

            if (deletedIngredient != null)
            {
                TempData["message"] = $"{deletedIngredient.Name} was deleted";
            }

            return RedirectToAction(nameof(List));
        }

    }


}
