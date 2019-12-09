using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe2019W.Models;
using Recipe2019W.Infrastructure;
using Recipe2019W.Models.ViewModels;

namespace Recipe2019W.Controllers
{
    public class IngredientListController:Controller
    {
        private IIngredientRepository repository;
        private IngredientList list;

        public IngredientListController(IIngredientRepository repo, IngredientList ingredientListService)
        {
            repository = repo;
            list = ingredientListService;
        }

        public ViewResult Index()
        {
            return View();
        }

        public RedirectToActionResult AddToList(int ingredientID, int quantity, string unit)
        {
            Ingredient ingredient = repository.Ingredients
                .FirstOrDefault(i => i.IngredientID == ingredientID);
            if (ingredient != null)
            {
                list.AddItem(ingredient, quantity, unit);
            }

            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult RemoveFromList(int ingredientID)
        {
            Ingredient ingredient = repository.Ingredients
                .FirstOrDefault(i => i.IngredientID == ingredientID);
            if (ingredient != null)
            {
                list.RemoveLine(ingredient);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
