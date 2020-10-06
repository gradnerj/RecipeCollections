using RecipeCollections.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IReviewRepository {
        IEnumerable<SelectListItem> GetReviewList();
        void Update(Review review);
    }
}
