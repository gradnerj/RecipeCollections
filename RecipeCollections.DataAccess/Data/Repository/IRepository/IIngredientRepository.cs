using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IIngredientRepository {
        IEnumerable<SelectListItem> GetIngredientList();
        void Update(Ingredient ingredient);
    }
}
