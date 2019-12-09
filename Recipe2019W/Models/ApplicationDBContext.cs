using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Recipe2019W.Models
{

    // This is the Database Class to be used by the Repository Class
    public class ApplicationDBContext : DbContext
    {
        // Constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        // Dataset of Recipes, get the recipes from database.
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
