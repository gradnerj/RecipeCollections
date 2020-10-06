using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUntensilRepository {
        IEnumerable<SelectListItem> GetUtensilList();
        void Update(Utensil utensil);
    }
}
