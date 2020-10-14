using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
            RecipeIds = HttpContext.Session.Get<List<int>>(StaticDetails.RecentlyViewed);
            RecipeList = new List<Recipe>();
            foreach(var id in RecipeIds) { 
                RecipeList.Add(_unitOfWork.Recipe.GetFirstorDefault(r => r.Id == id, "Category"));
            }
        }
    }
}
