using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using RecipeCollections.Utility;

namespace RecipeCollections.Pages
{
    public class RecentlyViewedModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public RecentlyViewedModel(ApplicationDbContext context, IUnitOfWork unitOfWork) {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<int> RecipeIds { get; set; }
        public List<Recipe> RecipeList { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            RecipeIds = HttpContext.Session.Get<List<int>>(StaticDetails.RecentlyViewed);
            RecipeList = new List<Recipe>();
            foreach(var id in RecipeIds) {
                RecipeList.Add(await _context.Recipes.Include(r => r.RecipeCategories)
                    .ThenInclude(r => r.Category)
                    .SingleAsync(r => r.Id == id));
            }
        }
    }
}
