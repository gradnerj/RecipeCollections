using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeCollections.Models {
    public class RecipeCategory {
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }

        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
    }
}
