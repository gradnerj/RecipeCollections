using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCollections.Models.Models.RecipeViewModels {
    public class RecipeIndexData {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
