using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;


namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface ICreatorRepository {
        IEnumerable<SelectListItem> GetCreatorList();
        void Update(Creator creator);
    }
}
