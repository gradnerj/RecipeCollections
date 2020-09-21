using RecipeCollections.Models.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface ICreatorRepository {
        IEnumerable<SelectListItem> GetCreatorList();
        void Update(Creator creator);
    }
}
