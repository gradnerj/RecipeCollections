using RecipeCollections.Models.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IRecipeRepository {
        IEnumerable<SelectListItem> GetRecipeList();
        void Update(Recipe recipe);
    }
}
