﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public class IngredientLine
    {
        public int IngredientCollID { get; set; }
        public Ingredient Ingredient{ get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set;}
    }
}