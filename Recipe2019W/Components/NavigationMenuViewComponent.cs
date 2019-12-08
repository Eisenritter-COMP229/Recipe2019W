using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe2019W.Models;

namespace Recipe2019W.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IRecipeRepository repository;
        public NavigationMenuViewComponent(IRecipeRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Recipes
                .Select(x => x.Type)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
