using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCollections.Data;
using RecipeCollections.Models;
using RecipeCollections.Utility;

namespace RecipeCollections.Pages
{
    public class RecentlyViewedModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public RecentlyViewedModel(ApplicationDbContext context) {
            _context = context;
        }

        public List<int> RecipeIds { get; set; }
        public List<Recipe> RecipeList { get; set; }
        public void OnGet()
        {
            RecipeIds = HttpContext.Session.Get<List<int>>(StaticDetails.RecentlyViewed);
            RecipeList = new List<Recipe>();
            foreach(var id in RecipeIds) { 
                RecipeList.Add(_context.Recipes.Where(r => r.Id == id).FirstOrDefault());
            }
        }
    }
}
