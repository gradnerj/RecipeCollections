using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.Data;
using RecipeCollections.Models.Models.RecipeViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RecipeCollections.Pages.Admin.Recipe {
    public class RecipeCategoriesPageModel : PageModel {

        public List<RecipeCategoryData> RecipeCategoryDataList;
        public void PopulateRecipeCategories(ApplicationDbContext context,
                                               Models.Recipe recipe) {
            var allCategories = context.Categories;
            var recipeCategories = new HashSet<int>(
                recipe.RecipeCategories.Select(c => c.CategoryId));
            RecipeCategoryDataList = new List<RecipeCategoryData>();
            foreach (var category in allCategories) {
                RecipeCategoryDataList.Add(new RecipeCategoryData {
                    CategoryId = category.Id,
                    Name = category.Name
                });
            }
        }
    }
}
