using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IStepRepository {
        IEnumerable<SelectListItem> GetStepList();
        void Update(Step step);
    }
}
