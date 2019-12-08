using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    // This is the Recipe Model
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumOfServings { get; set; }
        public int PrepTime { get; set; }
        public int TotalTime { get; set; }
        public string Type { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string TotalTimeS => (TotalTime / 60).ToString() + " HR " + (TotalTime % 60).ToString() + " MIN ";

        public Recipe()
        {
        }
    }
}
