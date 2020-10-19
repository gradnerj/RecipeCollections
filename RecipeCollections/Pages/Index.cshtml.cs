using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeCollections.Data;
using RecipeCollections.DataAccess.Data.Repository;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using RecipeCollections.Models;
using RecipeCollections.Models.Models.RecipeViewModels;
using RecipeCollections.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecipeCollections.Pages {
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public string TitleSort { get; set; }
        public string CategorySort { get; set; }
        public string PrepTimeSort { get; set; }
        public string CookTimeSort { get; set; }
        public string FeedsQtySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Recipe> Recipes { get; set; }
        public Dictionary<int, int> AvgReviews { get; set; }
        public RecipeIndexData RecipeData { get; set; }
        public async Task OnGetAsync(string sortType, string searchString, string currentFilter, int? pageIndex)
        {

            RecipeData = new RecipeIndexData();
            RecipeData.Recipes = await _context.Recipes
                .Include(r => r.RecipeCategories)
                    .ThenInclude(r => r.Category).ToListAsync();
            CurrentSort = sortType;
            TitleSort = String.IsNullOrEmpty(sortType) ? "title_desc" : "";
            PrepTimeSort = sortType == "PrepTime" ? "preptime_desc" : "PrepTime";
            CookTimeSort = sortType == "CookTime" ? "cooktime_desc" : "CookTime";
            FeedsQtySort = sortType == "FeedsQty" ? "feedsqty_desc" : "FeedsQty";
            
            if(searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }
            
            CurrentFilter = searchString;

            var recipesIQ = RecipeData.Recipes.AsQueryable<Models.Recipe>();


            var result = getFilteredSorted(sortType, CurrentFilter, recipesIQ);
            int pageSize = 3;
            Recipes = PaginatedList<Models.Recipe>.Create(result.AsNoTracking(), pageIndex ?? 1, pageSize);
            RecipeData.Recipes = Recipes;
            AvgReviews = new Dictionary<int, int>();
            foreach(var r in Recipes) {
                var reviews = _context.Reviews.Where(rev => rev.RecipeId == r.Id);
                int totalRevs = reviews.Count();
                if(totalRevs == 0) {
                    AvgReviews.Add(r.Id, 0);
                } else {
                    int reviewsSum = 0;
                    foreach(var i in reviews) {
                        reviewsSum += i.Rating;
                    }
                    AvgReviews.Add(r.Id, reviewsSum / totalRevs);
                }
            }
        }
  
        public IActionResult OnPostReview(int val, int recipeid) {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var id = claim.Value;
            var review = new Review() {
                RecipeId = recipeid,
                Rating = val,
                CreatorId = id
            };
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Redirect("/Index");
        }

        private IQueryable<Models.Recipe> getFilteredSorted(string sortType, string filterBy, IQueryable<Models.Recipe> recipesIQ) {
            //IQueryable<Models.Recipe> recipesIQ = _unitOfWork.Recipe.GetAll(null, null,"Category");
            //IQueryable<Models.Recipe> recipesIQ = RecipeData.Recipes.AsQueryable();
            if (!String.IsNullOrEmpty(filterBy)) {
                recipesIQ = recipesIQ.Where(r => r.Title.ToLower().Contains(filterBy.ToLower()) || r.RecipeCategories.Any(c => c.Category.Name.ToLower().Contains(filterBy.ToLower())));
            }
            switch (sortType) {
                case "title_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.Title);
                    return recipesIQ;
                //case "category_desc":
                //   // recipesIQ = recipesIQ.OrderByDescending(r => r.Category.Name);
                //    return recipesIQ;
                //case "Category":
                //   // recipesIQ = recipesIQ.OrderBy(r => r.Category.Name);
                //    return recipesIQ;
                case "preptime_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.PrepTime);
                    return recipesIQ;
                case "PrepTime":
                    recipesIQ = recipesIQ.OrderBy(r => r.PrepTime);
                    return recipesIQ;
                case "cooktime_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.CookTime);
                    return recipesIQ;
                case "CookTime":
                    recipesIQ = recipesIQ.OrderBy(r => r.CookTime);
                    return recipesIQ;
                case "feedsqty_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.FeedsQty);
                    return recipesIQ;
                case "FeedsQty":
                    recipesIQ = recipesIQ.OrderBy(r => r.FeedsQty);
                    return recipesIQ;
                case "creatorid_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.CreatorId);
                    return recipesIQ;
                case "CreatorID":
                    recipesIQ = recipesIQ.OrderBy(r => r.CreatorId);
                    return recipesIQ;
                default:
                    recipesIQ = recipesIQ.OrderBy(r => r.Title);
                    return recipesIQ;
            }
        }
    }
}
