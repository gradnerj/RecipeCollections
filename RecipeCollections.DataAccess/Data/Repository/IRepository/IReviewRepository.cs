using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeCollections.Models;
using System.Collections.Generic;

namespace RecipeCollections.DataAccess.Data.Repository.IRepository {
    public interface IReviewRepository {
        IEnumerable<SelectListItem> GetReviewList();
        void Update(Review review);
    }
}
