using RecipeCollections.Models.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IUntensilRepository {
        IEnumerable<SelectListItem> GetUtensilList();
        void Update(Utensil utensil);
    }
}
