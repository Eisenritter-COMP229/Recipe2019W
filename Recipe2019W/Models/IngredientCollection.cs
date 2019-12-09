using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe2019W.Models
{
    public class IngredientCollection
    {
        private List<IngredientLine> lineCollection = new List<IngredientLine>();

        public virtual void AddItem(Ingredient ingredient, int quantity, string unit)
        {
            IngredientLine line = lineCollection
                .Where(i => i.Ingredient.IngredientID == ingredient.IngredientID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new IngredientLine
                {
                    Ingredient = ingredient,
                    Quantity = quantity,
                    Unit = unit
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Ingredient ingredient) =>
            lineCollection.RemoveAll(l => l.Ingredient.IngredientID == ingredient.IngredientID);

        public virtual void clear() => lineCollection.Clear();

        public IEnumerable<IngredientLine> Lines => lineCollection;
    }
}
