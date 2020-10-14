using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Utility;

namespace RecipeCollections.Pages {
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context, IUnitOfWork unitOfWork) {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public Models.Recipe Recipe { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync(int id)
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
            Recipe = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .ThenInclude(r => r.Category)
                .SingleAsync(r => r.Id == id);
        }
    }
}
