using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IStepRepository {
        IEnumerable<SelectListItem> GetStepList();
        void Update(Step step);
    }
}
