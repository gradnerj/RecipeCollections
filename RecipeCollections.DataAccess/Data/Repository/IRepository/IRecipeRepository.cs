using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;


namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IRecipeRepository : IRepository<Recipe>{
        IEnumerable<SelectListItem> GetRecipeList();
        void Update(Recipe recipe);
    }
}
