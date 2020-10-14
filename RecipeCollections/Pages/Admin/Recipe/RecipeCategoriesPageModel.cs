using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.Data;
using RecipeCollections.Models;
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


        public void UpdateRecipeCategories(ApplicationDbContext context,
           string[] selectedCategories, Models.Recipe recipeToUpdate) {
            if (selectedCategories == null) {
                recipeToUpdate.RecipeCategories = new List<RecipeCategory>();
                return;
            }

            var selectedCategoryHS = new HashSet<string>(selectedCategories);
            var recipeCategories = new HashSet<int>
                (recipeToUpdate.RecipeCategories.Select(c => c.Category.Id));
            foreach (var category in context.Categories) {
                if (selectedCategoryHS.Contains(category.Id.ToString())) {
                    if (!recipeCategories.Contains(category.Id)) {
                        recipeToUpdate.RecipeCategories.Add(
                            new RecipeCategory {
                                RecipeId = recipeToUpdate.Id,
                                CategoryId = category.Id
                            });
                    }
                } else {
                    if (recipeCategories.Contains(category.Id)) {
                        RecipeCategory categoryToRemove
                            = recipeToUpdate
                                .RecipeCategories
                                .SingleOrDefault(i => i.CategoryId == category.Id);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }

    }
}
