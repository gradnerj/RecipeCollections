using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;


namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IIngredientRepository {
        IEnumerable<SelectListItem> GetIngredientList();
        void Update(Ingredient ingredient);
    }
}
