using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Utility;

namespace RecipeCollections.Pages {
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public Models.Recipe Recipe { get; set; }
        public void OnGet(int id)
        {
            List<int> recipeid_list = null;
            int recent_count = 0;
            //Empty session
            if (HttpContext.Session.Get<List<int>>(StaticDetails.RecentlyViewed) == default) {
                recipeid_list = new List<int>();
                
            } else {
                recipeid_list = HttpContext.Session.Get<List<int>>(StaticDetails.RecentlyViewed);
            }
            recent_count = HttpContext.Session.Get<int>(StaticDetails.RecentlyViewedCount);
            if (!recipeid_list.Exists(rId => rId == id)) {
                recipeid_list.Add(id);
                recent_count++;
            }
            

            HttpContext.Session.Set(StaticDetails.RecentlyViewed, recipeid_list);
            HttpContext.Session.Set(StaticDetails.RecentlyViewedCount, recent_count);
            Recipe = _unitOfWork.Recipe.GetFirstorDefault(r => r.Id == id,  "Category");
        }
    }
}
